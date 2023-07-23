using AutoMapper;
using BrainGame.Db.Entities.Quiz;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Quiz.Models;
using BrainGame.Core.Utilities;
using BrainGame.Logic.QuizService.CorrectService;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.Quiz.Utilities;
using BrainGame.Core.Exceptions;
using System.Security.Claims;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectController : ControllerBase
    {
        private readonly ICorrectService _service;
        private readonly IStatisticsService _statisticsService;
        private readonly IMapper _mapper;

        public CorrectController(ICorrectService service, IStatisticsService statisticsService,  IMapper mapper)
        {
            _service = service;
            _statisticsService = statisticsService;
            _mapper = mapper;
        }

        [HttpPost("id")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> Correct(CorrectWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = GetUserId();

                var mappedCorrect = _mapper.Map<Correct>(model);

                var result = await _service.Correct(mappedCorrect);

                if (result)
                {
                    await _statisticsService.AddPoint(id, userId);
                }

                return NoContent();
            }
            catch (CorrectNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        private int GetUserId()
        {
            var userId = HttpContext.User.Claims
                .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!.Value;

            var result = int.TryParse(userId, out var id);

            if (!result)
            {
                throw new UserNotFoundException("User not found");
            }

            return id;
        }
    }
}