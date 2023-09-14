using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UsersService.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<IEnumerable<Gender>> GetAllGendersAsync();

        Task EditUserAsync(User user, int id);

        Task EditPasswordAsync(Password password, int id);
    }
}