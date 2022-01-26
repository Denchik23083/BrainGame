using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Db.Entities;
using BrainGame.Logic.QuizService;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _service;
        private static Quizzes _quiz;

        public QuizController(IQuizService service)
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

            switch (_quiz.Name)
            {
                case "Animals":
                    question = await _service.GetAnimalsQuestions(id);
                    break;
                case "Plants":
                    question = await _service.GetPlantsQuestions(id);
                    break;
                case "Mushrooms":
                    question = await _service.GetMushroomsQuestions(id);
                    break;
            }

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