using BrainGame.Core.Exceptions;
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

        public async Task<IEnumerable<User>> GetAdmins(int roleId)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Where(_ => _.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<User> GetAdmin(int id)
        {
            var admin = await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (admin is null)
            {
                throw new AdminNotFoundException("Admin not found");
            }

            return admin;
        }

        public async Task RemoveUser(User userToRemove)
        {
            _context.Users.Remove(userToRemove);
            _context.RefreshTokens.Remove(userToRemove.RefreshToken!);

            await _context.SaveChangesAsync();
        }
    }
}
