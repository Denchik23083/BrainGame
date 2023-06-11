using BrainGame.Core;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UserService
{
    public interface IUserService
    {
        Task<User> GetUser();

        Task Update(User user);

        Task Remove();

        Task Password(Password model);
    }
}