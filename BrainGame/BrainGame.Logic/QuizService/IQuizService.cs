using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService
{
    public interface IQuizService
    {
        Task<Quizzes> GetQuiz(Quizzes model);

        Task<Questions> GetQuestions(int id);
    }
}