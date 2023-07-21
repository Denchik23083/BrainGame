using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.Core.Exceptions;
using System.Security.Claims;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;

        public StatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticsAsync()
        {
            var statistics = await _service.GetStatistics();

            return Ok(statistics);
        }

        [HttpGet("id/points")]
        public IActionResult GetPoints(int id)
        {
            _service.Clear();

            return NoContent();
        }

        [HttpPost("id")]
        public async Task<IActionResult> CreateSessionAsync(int id)
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

                await _service.CreateSession(id, userId);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}