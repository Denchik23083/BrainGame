using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _service;

        public RegisterController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var register = await _service.Register(Map(model));

            return Ok(register);
        }

        private Register Map(RegisterModel model)
        {
            return new Register
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
            };
        }
    }
}