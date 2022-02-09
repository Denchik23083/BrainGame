using System;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using BrainGame.WebDb.QuizRepository;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Logic.QuizService
{
    public class CorrectsService : ICorrectsService
    {
        private readonly BrainGameContext _context;
        private readonly ICorrectsRepository _repository;

        public CorrectsService(ICorrectsRepository repository, BrainGameContext context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task Correct(Correct correctAnswerUser)
        {
            var correct = await _repository.Correct(QuizService.CorrectId);
            var correctAnswer = correct.CorrectAnswer;

            var correctUser = correctAnswerUser.CorrectAnswer;

            if (correctAnswer == correctUser)
            {
                var getPoint = await _context.Quizzes
                                    .FirstOrDefaultAsync(p => p.Id == QuizService.Quiz.Id);

                if (getPoint is null)
                {
                    throw new ArgumentNullException();
                }

                getPoint.Point++;

                await _context.SaveChangesAsync();
            }
        }
    }
}