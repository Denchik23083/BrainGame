using System.Collections.Generic;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IStatisticsRepository
    {
        IEnumerable<Quizzes> GetStatistics();
    }
}
