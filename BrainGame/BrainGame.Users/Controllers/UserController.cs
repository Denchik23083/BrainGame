using System.Security.Claims;
using AutoMapper;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.Users.Models;
using BrainGame.Users.Utilities;
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

        [HttpGet]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetUsers();

                var mapperUsers = _mapper.Map<IEnumerable<UserReadModel>>(users);

                return Ok(mapperUsers);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> EditUser(UserWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!.Value;

                var result = int.TryParse(userId, out var id);

                if (!result)
                {
                    throw new UserNotFoundException("User not found");
                }

                var mappedUser = _mapper.Map<User>(model);

                await _service.EditUser(mappedUser, id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("password")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> EditPassword(PasswordWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!.Value;

                var result = int.TryParse(userId, out var id);

                if (!result)
                {
                    throw new UserNotFoundException("User not found");
                }

                var mappedPassword = _mapper.Map<Password>(model);

                await _service.EditPassword(mappedPassword, id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}