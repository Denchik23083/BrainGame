using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable<Statistics>> GetAllStatisticsAsync(int userId);

        Task SavePointsAsync(Statistics statistic);

        Task ResetStatisticsAsync(IEnumerable<Statistics> statistics);
    }
}