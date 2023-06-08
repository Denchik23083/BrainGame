using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IPointRepository
    {
        Task<Quizzes> GetPoint(int quizId);

        Task RemovePoint(Quizzes quizzes);
    }
}