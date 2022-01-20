using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using BrainGame.WebDb;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Logic
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
            var correct = await _repository.Correct(QuizService._correctId);
            var correctAnswer = correct.CorrectAnswer;

            var correctUser = correctAnswerUser.CorrectAnswer;

            if (correctAnswer == correctUser)
            {
                var getPoint = await _context.Quizzes
                                    .FirstOrDefaultAsync(p => p.Id == QuizService._quiz.Id);

                if (getPoint is null)
                {
                    throw new ArgumentNullException();
                }

                getPoint.Point++;

                _context.Quizzes.Update(QuizService._quiz);

                await _context.SaveChangesAsync();
            }
        }
    }
}