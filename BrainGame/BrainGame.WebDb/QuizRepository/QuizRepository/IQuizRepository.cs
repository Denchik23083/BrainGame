using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository.QuizRepository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quizzes>> GetAllQuizzesAsync();

        Task<Quizzes?> GetQuizAsync(int id);

        Task CreateQuizAsync(Quizzes quiz);

        Task UpdateQuizAsync(Quizzes quizToUpdate);

        Task DeleteQuizAsync(Quizzes quizToDelete);
    }
}