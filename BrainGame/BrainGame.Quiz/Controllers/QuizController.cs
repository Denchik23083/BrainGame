using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetQuiz(QuizzesModel model)
        {
            model.Point = 0;
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
                question = _service.GetAnimalsQuestions(id);
            }
            else if (_quiz.Name == "Растения")
            {
                question = _service.GetPlantsQuestions(id);
            }
            else if (_quiz.Name == "Грибы")
            {
                question = _service.GetMushroomsQuestions(id);
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