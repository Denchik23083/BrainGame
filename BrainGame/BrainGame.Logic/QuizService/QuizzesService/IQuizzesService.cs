using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService.QuizzesService
{
    public interface IQuizzesService
    {
        Task<IEnumerable<Quizzes>> GetQuizzes();

        Task<IEnumerable<Questions>> GetQuestions(int quizId);
    }
}