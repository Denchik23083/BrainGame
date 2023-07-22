using AutoMapper;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Logic.QuizService.QuestionService;
using BrainGame.Quiz.Models;
using BrainGame.Quiz.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("id")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetQuestions(int id)
        {
            try
            {
                var questions = await _service.GetQuestions(id);

                var mappedQuestions = _mapper.Map<IEnumerable<QuestionReadModel>>(questions);

                return Ok(mappedQuestions);
            }
            catch (QuestionNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
