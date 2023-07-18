using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly BrainGameContext _context;

        public StatisticsRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Quizzes> GetPoint(int quizId)
        {
            return (await _context.Quizzes.FirstOrDefaultAsync(p => p.Id == quizId))!;
        }

        public async Task RemovePoint(Quizzes quizzes)
        {
            //quizzes.Point = 0;

            await _context.SaveChangesAsync();
        }
    }
}