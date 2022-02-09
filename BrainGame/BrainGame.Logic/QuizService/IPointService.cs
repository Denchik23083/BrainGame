using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.Logic.QuizService
{
    public interface IPointService
    {
        Task<Quizzes> GetPoint();

        Task RemovePoint();

        void Result();
    }
}