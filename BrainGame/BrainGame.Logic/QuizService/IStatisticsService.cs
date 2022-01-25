using System.Collections.Generic;
using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();

        void Clear();
    }
}