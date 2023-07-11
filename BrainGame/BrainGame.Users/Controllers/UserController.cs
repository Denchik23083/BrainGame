using System.Security.Claims;
using AutoMapper;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.UserService;
using BrainGame.Users.Models;
using BrainGame.Users.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Users.Controllers
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

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditUser(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userEmail = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.Email)!.Value;

                var mappedUser = _mapper.Map<User>(model);

                await _service.EditUser(mappedUser, userEmail);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("password")]
        [Authorize]
        public async Task<IActionResult> EditPassword(PasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userEmail = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.Email)!.Value;

                var mappedPassword = _mapper.Map<Password>(model);

                await _service.EditPassword(mappedPassword, userEmail);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [RequirePermission(PermissionType.RemoveUser)]
        public async Task<IActionResult> RemoveUser()
        {
            try
            {
                var userEmail = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.Email)!.Value;

                await _service.RemoveUser(userEmail);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}