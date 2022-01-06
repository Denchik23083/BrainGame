using System.Collections.Generic;
using BrainGame.Db;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly BrainGameContext _context;

        public StatisticsRepository(BrainGameContext context)
        {
            _context = context;
        }

        public IEnumerable<Quizzes> GetStatistics()
        {
            return _context.Quizzes;
        }
    }
}