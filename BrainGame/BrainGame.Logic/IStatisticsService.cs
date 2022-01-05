using System.Collections.Generic;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();
    }
}
