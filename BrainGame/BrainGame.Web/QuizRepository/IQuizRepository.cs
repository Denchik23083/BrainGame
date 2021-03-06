using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IQuizRepository
    {
        Task<Quizzes> GetQuiz(Quizzes model);

        Task<Questions> GetQuestions(int id);
    }
}