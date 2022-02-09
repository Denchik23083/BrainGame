using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var user = _service.Get();

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserModel model)
        {
            await _service.Update(Map(model));

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove()
        {
            await _service.Remove();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Password(PasswordModel model)
        {
            await _service.Password(Map(model));

            return NoContent();
        }

        private User Map(UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
            };
        }

        private Password Map(PasswordModel model)
        {
            return new Password
            {
                OldPassword = model.OldPassword,
                NewPassword = model.NewPassword,
                ConfirmPassword = model.ConfirmPassword,
            };
        }
    }
}