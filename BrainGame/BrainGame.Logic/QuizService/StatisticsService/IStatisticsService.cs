using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.StatisticsService
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Statistics>> GetStatistics(int userId);

        Task CreateSession(int quizId, int userId);

        Task AddPoint(int quizId, int userId);

        Task<Statistics> GetPoints(int quizId, int userId);

        Task ResetStatistics(int userId);
    }
}