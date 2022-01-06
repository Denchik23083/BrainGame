using System.Threading.Tasks;
using BrainGame.Db.Entities;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersService _service;

        public AnswersController(IAnswersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAnswers()
        {
            var answers = _service.GetAnswers();

            return Ok(answers);
        }

        [HttpPost]
        public async Task<IActionResult> Correct(CorrectModel model)
        {
            await _service.Correct(Map(model));

            return NoContent();
        }

        private Correct Map(CorrectModel model)
        {
            return new Correct
            {
                Id = model.Id,
                CorrectAnswer = model.CorrectAnswer
            };
        }
    }
}