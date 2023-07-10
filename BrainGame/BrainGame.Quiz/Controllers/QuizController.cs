using Microsoft.AspNetCore.Mvc;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _service;

        public QuizController(IQuizService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetQuiz(QuizzesModel model)
        {
            var quiz = await _service.GetQuiz(Map(model));

            return Ok(quiz);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Question(int id)
        {
            var question = await _service.GetQuestions(id);

            return Ok(question);
        }

        private Quizzes Map(QuizzesModel model)
        {
            return new Quizzes
            {
                Id = model.Id,
                Name = model.Name,
                Point = model.Point
            };
        }
    }
}