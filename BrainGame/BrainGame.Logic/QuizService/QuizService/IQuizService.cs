using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuizService
{
    public interface IQuizService
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();

        Task CreateQuiz(Quizzes quiz);

        Task UpdateQuiz(Quizzes quiz, int id);

        Task DeleteQuiz(int id);
    }
}