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
    public class QuizesController : ControllerBase
    {
        private readonly IService _service;

        public QuizesController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult GetQuiz(QuizesModel model)
        {
            //write _quiz
            return Ok(_service.Quiz(Map(model)));
        }

        [HttpGet("id")]
        public IActionResult Question(int id)
        {
            //switch which question give 
            return Ok(_service.GetQuestion(id));
        }

        [HttpPost]
        public IActionResult Correct(int answerId)
        {
            _service.Correct(answerId);

            return NoContent();
        }

        private Quizes Map(QuizesModel model)
        {
            return new Quizes
            {
                Id = model.Id,
                Name = model.Name,
                Point = model.Point
            };
        }
    }
}
