using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuizService
{
    public interface IQuizService
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();
    }
}