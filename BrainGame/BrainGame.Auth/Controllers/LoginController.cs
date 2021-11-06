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
        public IActionResult Login(LoginModel model)
        {
            var login = _service.Login(Map(model));

            return Ok(login);
        }

        private LoginModel Map(Login model)
        {
            return new LoginModel
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
            };
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
