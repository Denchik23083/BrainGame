using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable<Statistics>> GetStatistics(int userId);

        Task SavePoints(Statistics statistic);

        Task ResetStatistics(IEnumerable<Statistics> statistics);
    }
}