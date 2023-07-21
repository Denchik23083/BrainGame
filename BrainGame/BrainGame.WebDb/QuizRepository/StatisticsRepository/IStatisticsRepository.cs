using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable<Statistics>> GetStatistics();

        Task<Quizzes> GetPoint(int quizId);

        Task RemovePoint(Quizzes quizzes);
    }
}