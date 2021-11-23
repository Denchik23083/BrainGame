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
    public class QuestionController : ControllerBase
    {
        private readonly IService _service;

        public QuestionController(IService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public IActionResult Question(int id)
        {
            return Ok(_service.GetQuestion(id));
        }

        [HttpPost]
        public IActionResult Correct(string answer)
        {
            _service.Correct(answer);

            return NoContent();
        }
    }
}
