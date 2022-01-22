using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public interface ICorrectsService
    {
        Task Correct(Correct correctAnswerUser);
    }
}