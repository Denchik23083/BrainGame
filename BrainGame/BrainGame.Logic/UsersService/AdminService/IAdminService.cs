using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.UsersService.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAllAdminsAsync();

        Task RemoveUserAsync(int id);
    }
}