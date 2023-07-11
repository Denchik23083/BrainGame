using BrainGame.Core.Utilities;
using BrainGame.Quiz.Models;
using BrainGame.Quiz.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<WeatherModel> Weathers = new()
        {
            new WeatherModel
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(Summaries.Length)]
            }
        };

        [HttpGet]
        [RequirePermission(PermissionType.GetQuiz)]
        public IActionResult GetAll()
        {
            return Ok(Weathers);
        }

        [HttpPost]
        [RequirePermission(PermissionType.EditQuiz)]
        public IActionResult CreateWeather(WeatherModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Weathers.Add(model);

            return NoContent();
        }
    }
}
