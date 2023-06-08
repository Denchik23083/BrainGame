using BrainGame.Db.Entities.Quiz;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectsController : ControllerBase
    {
        private readonly ICorrectsService _service;

        public CorrectsController(ICorrectsService service)
        {
            _service = service;
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