using AutoMapper;
using BrainGame.Db.Entities.Quiz;
using Microsoft.AspNetCore.Mvc;
using BrainGame.Logic.QuizService;
using BrainGame.Quiz.Models;
using BrainGame.Core.Utilities;
using BrainGame.Quiz.Utilities;

namespace BrainGame.Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectController : ControllerBase
    {
        private readonly ICorrectsService _service;
        private readonly IMapper _mapper;

        public CorrectController(ICorrectsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [RequirePermission(PermissionType.GetQuiz)]
        public async Task<IActionResult> Correct(CorrectWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedCorrect = _mapper.Map<Correct>(model);

                await _service.Correct(mappedCorrect);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}