using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.UsersRepository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BrainGameContext _context;

        public AdminRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAdminsAsync(int roleId)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Where(_ => _.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<User?> GetAdminAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task RemoveUserAsync(User userToRemove)
        {
            _context.Users.Remove(userToRemove);

            await _context.SaveChangesAsync();
        }
    }
}
