using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Users.Utilities;
using AutoMapper;
using BrainGame.Logic.UserService;

namespace BrainGame.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _service;

        public AdminController(IUserService service)
        {
            _service = service;
        }

        [HttpDelete("id")]
        [RequirePermission(PermissionType.RemoveUser)]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                await _service.RemoveUser(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
