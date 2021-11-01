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
    public class BrainGameController : ControllerBase
    {
        private readonly IService _service;

        public BrainGameController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            var register = _service.Register(Map(model));

            return Ok(register);
        }

        private RegisterModel Map(Register model)
        {
            return new RegisterModel
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
            };
        }

        private Register Map(RegisterModel model)
        {
            return new Register
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
            };
        }
    }
}
