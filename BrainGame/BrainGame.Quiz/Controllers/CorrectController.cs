using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BrainGame.Db.Entities;
using BrainGame.Logic;
using BrainGame.Quiz.Models;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectController : ControllerBase
    {
        private readonly IService _service;

        public CorrectController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Correct(CorrectModel model)
        {
            await _service.Correct(Map(model));

            return NoContent();
        }

        private Correct Map(CorrectModel model)
        {
            return new Correct
            {
                Id = model.Id,
                CorrectAnswer = model.CorrectAnswer
            };
        }
    }
}