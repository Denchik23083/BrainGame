using BrainGame.Core;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser(User? user);

        Task Update(User userToUpdate, User user);

        Task Remove(User userToRemove);

        Task Password(User userToUpdate, Password model);
    }
}