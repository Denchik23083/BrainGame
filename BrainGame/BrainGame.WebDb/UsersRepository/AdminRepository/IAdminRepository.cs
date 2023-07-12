using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAdmins(int roleId);

        Task<User> GetAdmin(int id);

        Task RemoveUser(User userToRemove);
    }
}