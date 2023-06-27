﻿using BrainGame.Core.Utilities;
using BrainGame.Quiz.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        private static List<WeatherModel> Weathers = new()
        {
            new WeatherModel
            {
                Date = DateTime.Now,
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(Summaries.Length)]
            }            
        };        

        [HttpGet]
        [RequireRole(RoleType.User)]
        public IActionResult GetAll()
        {
            return Ok(Weathers);
        }

        [HttpPost]
        [RequireRole(RoleType.Admin)]
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
