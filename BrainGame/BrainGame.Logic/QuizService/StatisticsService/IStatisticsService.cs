using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Statistics>> GetStatistics();

        Task CreateSession(int quizId, int userId);

        Task AddPoint(int quizId, int userId);

        Task<Quizzes> GetPoint();

        Task RemovePoint();

        void Result();

        void Clear();
    }
}