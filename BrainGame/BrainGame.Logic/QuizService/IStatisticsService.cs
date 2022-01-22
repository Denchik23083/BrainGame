using System.Collections.Generic;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();
    }
}