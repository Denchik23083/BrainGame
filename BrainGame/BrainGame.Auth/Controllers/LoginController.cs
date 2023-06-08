using Microsoft.AspNetCore.Mvc;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _service;

        public LoginController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var login = await _service.Login(Map(model));

            if (login is null)
            {
                return BadRequest();
            }
            
            return Ok(login);
        }

        private Login Map(LoginModel model)
        {
            return new Login
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}