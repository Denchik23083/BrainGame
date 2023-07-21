using AutoMapper;
using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Logic.QuizService.QuestionService;
using BrainGame.Quiz.Models;
using BrainGame.Quiz.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BrainGame.Logic.QuizService.StatisticsService;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService service, IStatisticsService statisticsService, IMapper mapper)
        {
            _service = service;
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        [HttpGet("id")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetQuestions(int id)
        {
            try
            {
                var userClaimId = HttpContext.User.Claims
                    .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!.Value;

                var result = int.TryParse(userClaimId, out var userId);

                if (!result)
                {
                    throw new UserNotFoundException("User not found");
                }

                _statisticsService.Create(id, userId);

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
