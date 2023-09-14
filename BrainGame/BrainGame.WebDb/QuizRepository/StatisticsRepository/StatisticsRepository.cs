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

        public async Task<IEnumerable<Statistics>> GetAllStatisticsAsync(int userId)
        {
            return await _context.Statistics
                .Include(_ => _.Quizzes)
                .Where(_ => _.UserId == userId)
                .ToListAsync();
        }

        public async Task SavePointsAsync(Statistics? statistic)
        {
            if (statistic is not null)
            {
                await _context.Statistics.AddAsync(statistic);
            }

            await _context.SaveChangesAsync();
        }

        public async Task ResetStatisticsAsync(IEnumerable<Statistics> statistics)
        {
            _context.Statistics.RemoveRange(statistics);

            await _context.SaveChangesAsync();
        }
    }
}