using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAdminsAsync(int roleId);

        Task<User?> GetAdminAsync(int id);

        Task RemoveUserAsync(User userToRemove);
    }
}