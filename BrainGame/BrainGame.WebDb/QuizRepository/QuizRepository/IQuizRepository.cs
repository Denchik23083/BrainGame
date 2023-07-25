using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuizRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();
    }
}