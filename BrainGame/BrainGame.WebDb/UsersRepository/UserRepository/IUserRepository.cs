using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync(int roleId);

        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<User?> GetUserAsync(int id);

        Task EditUserAsync(User userToUpdate);

        Task EditPasswordAsync(User userToUpdate);
    }
}