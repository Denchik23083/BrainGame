using System.Collections.Generic;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IStatisticsRepository
    {
        IEnumerable<Quizzes> GetStatistics();
    }
}