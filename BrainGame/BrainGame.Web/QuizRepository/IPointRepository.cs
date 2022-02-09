using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository
{
    public interface IPointRepository
    {
        Task<Quizzes> GetPoint();

        Task RemovePoint();
    }
}