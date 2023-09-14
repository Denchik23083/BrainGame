using AutoMapper;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Quiz;
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
                var questions = await _service.GetQuestionsAsync(id);

                var mappedQuestions = _mapper.Map<IEnumerable<QuestionReadModel>>(questions);

                return Ok(mappedQuestions);
            }
            catch (QuestionNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> CreateQuestion(QuestionWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedQuestion = _mapper.Map<Questions>(model);

            await _service.CreateQuestionAsync(mappedQuestion);

            return NoContent();
        }

        [HttpPut("id")]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> UpdateQuestion(QuestionWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedQuestion = _mapper.Map<Questions>(model);

                await _service.UpdateQuestionAsync(mappedQuestion, id);

                return NoContent();
            }
            catch (QuestionNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("id")]
        [RequirePermission(PermissionType.EditQuiz)]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.DeleteQuestionAsync(id);

                return NoContent();
            }
            catch (QuestionNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
