using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using BrainGame.Core.Exceptions;
using BrainGame.Logic.UsersService.UserService;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service,
            IUserService userService,
            IConfiguration configuration, 
            IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Your password must match confirmPassword");
            }

            var mappedRegister = _mapper.Map<User>(model);

            await _service.RegisterAsync(mappedRegister);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedLogin = _mapper.Map<User>(model);

                var user = await _service.LoginAsync(mappedLogin);

                var tokenModel = await GetUserToken(user);

                return Ok(tokenModel);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login/refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedRefresh = _mapper.Map<RefreshToken>(model);

                var user = await _service.RefreshAsync(mappedRefresh);

                var tokenModel = await GetUserToken(user);

                return Ok(tokenModel);
            }
            catch (RefreshTokenNotFoundException e)
            {
                return BadRequest(e.Message);
            }

            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("register/gender")]
        public async Task<IActionResult> GetGenders()
        {
            try
            {
                var genders = await _userService.GetAllGendersAsync();

                var mapperGenders = _mapper.Map<IEnumerable<GenderModel>>(genders);

                return Ok(mapperGenders);
            }
            catch (GenderNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task<TokenModel> GetUserToken(User user)
        {
            var secretKey = _configuration["SecretKey"];

            var secret = Encoding.UTF8.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()!),
                new (ClaimTypes.Name, user.Name!),
                new (ClaimTypes.Email, user.Email!),
                new (ClaimTypes.Gender, user.Gender!.Type.ToString()!),
                new (ClaimTypes.Role, user.Role!.RoleType.ToString()!)
            };

            var permissions = user.Role!.RolePermissions!
                .Select(_ => new Claim("permission", _.PermissionType.ToString()!));

            claims.AddRange(permissions);

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                notBefore: now,
                expires: now.AddMinutes(5),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var refreshToken = Guid.NewGuid();

            if (user.RefreshToken is null)
            {
                await _service.CreateRefreshTokenAsync(refreshToken, user);
            }
            else
            {
                await _service.UpdateRefreshTokenAsync(refreshToken, user);
            }

            return new TokenModel { JwtToken = stringToken, RefreshToken = refreshToken };
        }
    }
}