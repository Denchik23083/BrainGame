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
    public class AnswersController : ControllerBase
    {
        private readonly IService _service;

        public AnswersController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAnswers()
        {
            var answers = _service.GetAnswers();

            return Ok(answers);
        }
    }
}
