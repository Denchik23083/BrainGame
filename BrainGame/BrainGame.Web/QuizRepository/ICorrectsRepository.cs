using System.Threading.Tasks;
using BrainGame.Db.Entities.Quiz;

namespace BrainGame.WebDb.QuizRepository
{
    public interface ICorrectsRepository
    {
        Task<Correct> Correct(int id);
    }
}