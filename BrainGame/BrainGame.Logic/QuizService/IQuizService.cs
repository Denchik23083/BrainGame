using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService
{
    public interface IQuizService
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();

        Task<IEnumerable<Questions>> GetQuestions(int quizId);
    }
}