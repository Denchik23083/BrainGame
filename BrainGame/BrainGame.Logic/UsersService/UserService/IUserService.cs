using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UsersService.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<IEnumerable<Gender>> GetGendersAsync();

        Task EditUserAsync(User user, int id);

        Task EditPasswordAsync(Password password, int id);
    }
}