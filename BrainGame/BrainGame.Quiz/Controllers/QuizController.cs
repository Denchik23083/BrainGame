using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.QuizService;
using BrainGame.Quiz.Models;
using BrainGame.Quiz.Utilities;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _service;
        private readonly IMapper _mapper;

        public QuizController(IQuizService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetQuizzes()
        {
            try
            {
                var quizzes = await _service.GetAllQuizzesAsync();

                var mappedQuizzes = _mapper.Map<IEnumerable<QuizReadModel>>(quizzes);

                return Ok(mappedQuizzes);
            }
            catch (QuizNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> CreateQuiz(QuizWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedQuiz = _mapper.Map<Quizzes>(model);

            await _service.CreateQuizAsync(mappedQuiz);

            return NoContent();
        }

        [HttpPut("id")]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> UpdateQuiz(QuizWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedQuiz = _mapper.Map<Quizzes>(model);

                await _service.UpdateQuizAsync(mappedQuiz, id);

                return NoContent();
            }
            catch (QuizNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("id")]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.DeleteQuizAsync(id);

                return NoContent();
            }
            catch (QuizNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}