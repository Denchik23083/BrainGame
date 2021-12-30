using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IService _service;

        public StatisticsController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            var statistics = _service.GetStatistics();

            return Ok(statistics);
        }
    }
}
