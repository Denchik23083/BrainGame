using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
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
                var quizzes = await _service.GetQuizzes();

                var mappedQuizzes = _mapper.Map<IEnumerable<QuizzesReadModel>>(quizzes);

                return Ok(mappedQuizzes);
            }
            catch (QuizzesNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetQuestions(int id)
        {
            try
            {
                var questions = await _service.GetQuestions(id);

                var mappedQuestions = _mapper.Map<IEnumerable<QuestionsReadModel>>(questions);

                return Ok(mappedQuestions);
            }
            catch (QuestionsNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}