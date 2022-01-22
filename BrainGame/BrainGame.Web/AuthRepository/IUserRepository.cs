using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb.AuthRepository
{
    public interface IUserRepository
    {
        User Get(User user);

        Task<User> Update(User user);

        Task Remove(int id);
    }
}