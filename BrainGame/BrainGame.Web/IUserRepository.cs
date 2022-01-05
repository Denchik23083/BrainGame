using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IUserRepository
    {
        User Get(User user);

        Task<User> Update(User user);

        Task Remove(int id);
    }
}
