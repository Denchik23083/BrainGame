using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BrainGame.Logic.QuizService;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IQuizService _service;

        public PointController(IQuizService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Point()
        {
            var point = await _service.GetPoint();

            return Ok(point);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePoint()
        {
            await _service.RemovePoint();

            return NoContent();
        }
    }
}