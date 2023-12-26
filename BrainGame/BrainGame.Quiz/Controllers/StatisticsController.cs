using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.Core.Exceptions;
using System.Security.Claims;
using AutoMapper;
using BrainGame.Core.Utilities;
using BrainGame.Quiz.Utilities;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;
        private readonly IMapper _mapper;

        public StatisticsController(IStatisticsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var userId = GetUserId();

                var statistics = await _service.GetAllStatisticsAsync(userId);

                var mappedStatistics = _mapper.Map<IEnumerable<StatisticsReadModel>>(statistics);

                return Ok(mappedStatistics);
            }
            catch (StatisticsNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> GetPoints(int id)
        {
            try
            {
                var userId = GetUserId();

                var points = await _service.GetPointsAsync(id, userId);

                var mappedPoints = _mapper.Map<StatisticsReadModel>(points);

                return Ok(mappedPoints);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StatisticsNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}")]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> CreateSession(int id)
        {
            try
            {
                var userId = GetUserId();

                await _service.CreateSessionAsync(id, userId);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StatisticsNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> ResetStatistics()
        {
            try
            {
                var userId = GetUserId();

                await _service.ResetStatisticsAsync(userId);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (StatisticsNotFoundException e)
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