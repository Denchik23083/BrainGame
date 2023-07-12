using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using BrainGame.Core.Exceptions;
using BrainGame.Logic.UsersService.UserService;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegisterController(IAuthService service, IUserService userService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("gender")]
        public async Task<IActionResult> GetGenders()
        {
            try
            {
                var genders = await _userService.GetGenders();

                var mapperGenders = _mapper.Map<IEnumerable<GenderModel>>(genders);

                return Ok(mapperGenders);
            }
            catch (GenderNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
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

            await _service.Register(mappedRegister);

            return NoContent();
        }
    }
}