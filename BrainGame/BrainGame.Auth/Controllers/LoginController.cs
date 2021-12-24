using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainGame.Auth.Models;
using BrainGame.Db.Entities;
using BrainGame.Logic;

namespace BrainGame.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService _service;

        public LoginController(IService service)
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