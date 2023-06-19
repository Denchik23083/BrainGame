using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using BrainGame.Logic.UserService;
using BrainGame.Core.Utilities;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Password(PasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.OldPassword != AuthService.User.Password || model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest();
            }

            var mappedPassword = _mapper.Map<Password>(model);

            await _service.Password(mappedPassword);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedUser = _mapper.Map<User>(model);

            await _service.Update(mappedUser);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove()
        {
            await _service.Remove();

            return NoContent();
        }
    }
}