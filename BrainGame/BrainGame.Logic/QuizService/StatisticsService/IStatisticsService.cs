using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public interface IStatisticsService
    {
        IEnumerable<Statistics> GetStatistics();

        void Create(int quizId, int userId);

        Task AddPoint(int questionId);

        Task<Quizzes> GetPoint();

        Task RemovePoint();

        void Result();

        void Clear();
    }
}