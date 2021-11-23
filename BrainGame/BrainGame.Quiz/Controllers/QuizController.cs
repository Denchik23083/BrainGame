using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IService _service;

        public QuizController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Quiz(int id)
        {
            return Ok(_service.Quiz(id));
        }
    }
}