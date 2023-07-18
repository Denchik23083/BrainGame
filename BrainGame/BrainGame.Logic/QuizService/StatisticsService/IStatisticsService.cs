using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public interface IStatisticsService
    {
        IEnumerable<Quizzes> GetStatistics();

        Task<Quizzes> GetPoint();

        Task RemovePoint();

        void Result();

        void Clear();
    }
}