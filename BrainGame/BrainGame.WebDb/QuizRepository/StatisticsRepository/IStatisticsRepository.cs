using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<Quizzes> GetPoint(int quizId);

        Task RemovePoint(Quizzes quizzes);
    }
}