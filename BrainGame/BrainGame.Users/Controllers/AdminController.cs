using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Users.Utilities;
using BrainGame.Logic.UsersService.AdminService;
using BrainGame.Users.Models;
using AutoMapper;

namespace BrainGame.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public AdminController(IAdminService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.AdminToUser)]
        public async Task<IActionResult> GetAdmins()
        {
            try
            {
                var admins = await _service.GetAllAdminsAsync();

                var mapperAdmins = _mapper.Map<IEnumerable<AdminReadModel>>(admins);

                return Ok(mapperAdmins);
            }
            catch (AdminNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("removeuser/id")]
        [RequirePermission(PermissionType.RemoveUser)]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                await _service.RemoveUserAsync(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
