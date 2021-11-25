using BrainGame.Db.Entities;
using BrainGame.Logic;
using BrainGame.Quizzes.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Quizzes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IService _service;
        private Quiz _quiz;

        public QuizController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult GetQuiz(QuizModel model)
        {
            var quiz = _service.Quiz(Map(model));
            _quiz = quiz;

            return Ok(quiz);
        }

        [HttpGet("id")]
        public IActionResult Question(int id)
        {
            object question = null;
            
            if (_quiz.Name == "Животные")
            {
                question = _service.GetQuestion(id);
            }
            else if(_quiz.Name == "Растения")
            {
                
            }
            else if (_quiz.Name == "Растения")
            {

            }
            else
            {
                return NoContent();
            }

            return Ok(question);
        }

        [HttpPost]
        public IActionResult Correct(int answerId)
        {
            _service.Correct(answerId);

            return NoContent();
        }

        private Quiz Map(QuizModel model)
        {
            return new Quiz
            {
                Id = model.Id,
                Name = model.Name,
                Point = model.Point
            };
        }
    }
}
