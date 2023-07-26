using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuizRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();

        Task<Quizzes> GetQuiz(int id);

        Task CreateQuiz(Quizzes quiz);

        Task UpdateQuiz(Quizzes quizToUpdate);

        Task DeleteQuiz(Quizzes quizToDelete);
    }
}