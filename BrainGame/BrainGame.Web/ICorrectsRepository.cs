using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface ICorrectsRepository
    {
        Task<Correct> Correct(int id);
    }
}