using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Logic.UsersService.GodService;
using BrainGame.Users.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GodController : ControllerBase
    {
        private readonly IGodService _service;

        public GodController(IGodService service)
        {
            _service = service;
        }

        [HttpPut("usertoadmin/id")]
        [RequirePermission(PermissionType.UserToAdmin)]
        public async Task<IActionResult> UserToAdmin(int id)
        {
            try
            {
                await _service.UserToAdminAsync(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("admintouser/id")]
        [RequirePermission(PermissionType.AdminToUser)]
        public async Task<IActionResult> AdminToUser(int id)
        {
            try
            {
                await _service.AdminToUserAsync(id);

                return NoContent();
            }
            catch (AdminNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
