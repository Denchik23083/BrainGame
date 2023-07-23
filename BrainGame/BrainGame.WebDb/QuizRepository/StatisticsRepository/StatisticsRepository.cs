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

        public async Task<IEnumerable<Statistics>> GetStatistics(int userId)
        {
            return await _context.Statistics
                .Where(_ => _.UserId == userId)
                .ToListAsync();
        }

        public async Task SavePoints(Statistics statistic)
        {
            await _context.Statistics.AddAsync(statistic);

            await _context.SaveChangesAsync();
        }

        public async Task ResetStatistics(IEnumerable<Statistics> statistics)
        {
            _context.Statistics.RemoveRange(statistics);

            await _context.SaveChangesAsync();
        }
    }
}