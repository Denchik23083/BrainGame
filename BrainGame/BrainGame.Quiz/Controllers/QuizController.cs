using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Db.Entities;
using BrainGame.Logic;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IService _service;
        private static Quizzes _quiz;

        public QuizController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetQuiz(QuizzesModel model)
        {
            var quiz = await _service.Quiz(Map(model));

            _quiz = quiz;

            return Ok(quiz);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Question(int id)
        {
            object question = null;

            if (_quiz.Name == "Animals")
            {
                question = await _service.GetAnimalsQuestions(id);
            }
            else if (_quiz.Name == "Plants")
            {
                question = await _service.GetPlantsQuestions(id);
            }
            else if (_quiz.Name == "Mushrooms")
            {
                question = await _service.GetMushroomsQuestions(id);
            }

            return Ok(question);
        }

        [HttpGet]
        public async Task<IActionResult> Point()
        {
            var point = await _service.GetPoint();

            return Ok(point);
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