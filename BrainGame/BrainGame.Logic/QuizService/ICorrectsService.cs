using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService
{
    public interface ICorrectsService
    {
        Task Correct(Correct correctAnswerUser);
    }
}