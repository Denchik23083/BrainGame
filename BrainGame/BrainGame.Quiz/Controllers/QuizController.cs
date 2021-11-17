using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IService _service;

        public QuizController(IService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public IActionResult GetQuestion(int id)
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