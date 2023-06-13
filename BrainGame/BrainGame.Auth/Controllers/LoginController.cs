using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginController(IAuthService service, IConfiguration configuration, IMapper mapper)
        {
            _service = service;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedLogin = _mapper.Map<User>(model);

            var user = await _service.Login(mappedLogin);

            if (user is null)
            {
                return BadRequest();
            }

            var tokenModel = await GetUserToken(user);

            return Ok(tokenModel);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Login(RefreshTokenModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _service.RefreshLogin(model.RefreshToken);

            var tokenModel = await GetUserToken(user);

            return Ok(tokenModel);
        }


        private async Task<TokenModel> GetUserToken(User user)
        {
            var secretKey = _configuration["SecretKey"];

            var secret = Encoding.UTF8.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Name!),
                new (ClaimTypes.Email, user.Email!)
            };

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                notBefore: now,
                expires: now.AddMinutes(10),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var refreshToken = Guid.NewGuid();

            if (user.RefreshToken is null)
            {
                await _service.CreateRefreshToken(refreshToken, user);
            }
            else
            {
                await _service.UpdateRefreshToken(refreshToken, user);
            }

            return new TokenModel { JwtToken = stringToken, RefreshToken = refreshToken };
        }
    }
}