using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<IEnumerable<Gender>> GetGenders();

        Task<User> GetUser(int id);

        Task EditUser(User user, int id);

        Task EditPassword(Password password, int id);

        Task RemoveUser(int id);
    }
}