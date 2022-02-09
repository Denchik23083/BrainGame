using System.Collections.Generic;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();

        void Clear();
    }
}