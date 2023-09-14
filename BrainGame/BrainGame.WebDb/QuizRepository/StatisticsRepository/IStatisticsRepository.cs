using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable<Statistics>> GetStatisticsAsync(int userId);

        Task SavePointsAsync(Statistics statistic);

        Task ResetStatisticsAsync(IEnumerable<Statistics> statistics);
    }
}