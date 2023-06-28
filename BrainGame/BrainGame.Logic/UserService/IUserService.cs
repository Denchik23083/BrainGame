using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UserService
{
    public interface IUserService
    {
        Task<User> GetUser(string userEmail);
        
        Task EditUser(User user, string userEmail);

        Task EditPassword(Password password, string userEmail);

        Task RemoveUser(string userEmail);
    }
}