using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IAnswersRepository
    {
        Task<Correct> Correct(int id);
    }
}
