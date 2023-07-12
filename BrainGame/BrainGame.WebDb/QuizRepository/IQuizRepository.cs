using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();

        Task<IEnumerable<Questions>> GetQuestions(int quizId);

        Task<Quizzes> GetQuiz(Quizzes model);

        Task AddPoints(Quizzes quizzes);
    }
}