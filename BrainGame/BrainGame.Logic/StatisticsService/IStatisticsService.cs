using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.StatisticsService
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();

        void Clear();
    }
}