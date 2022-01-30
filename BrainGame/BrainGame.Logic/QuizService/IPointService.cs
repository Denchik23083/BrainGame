using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic.QuizService
{
    public interface IPointService
    {
        Task<Quizzes> GetPoint();

        Task RemovePoint();

        void Result();
    }
}