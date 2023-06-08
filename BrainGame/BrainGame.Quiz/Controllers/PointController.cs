using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IPointService _service;

        public PointController(IPointService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Point()
        {
            var point = await _service.GetPoint();

            return Ok(point);
        }

        [HttpPost]
        public IActionResult Result()
        {
            _service.Result();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePoint()
        {
            await _service.RemovePoint();

            return NoContent();
        }
    }
}