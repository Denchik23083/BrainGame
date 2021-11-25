using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainGame.Logic;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectController : ControllerBase
    {
        private readonly IService _service;

        public CorrectController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Correct(int answerId)
        {
            _service.Correct(answerId);

            return Ok();
        }
    }
}