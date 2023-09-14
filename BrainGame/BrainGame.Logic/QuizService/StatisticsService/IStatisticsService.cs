using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Statistics>> GetAllStatisticsAsync(int userId);

        Task CreateSessionAsync(int quizId, int userId);

        Task AddPointAsync(int quizId, int userId);

        Task<Statistics> GetPointsAsync(int quizId, int userId);

        Task ResetStatisticsAsync(int userId);
    }
}