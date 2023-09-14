using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.UsersRepository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly BrainGameContext _context;

        public UserRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(int roleId)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Where(_ => _.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task EditUserAsync(User userToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task EditPasswordAsync(User userToUpdate)
        {
            await _context.SaveChangesAsync();
        }
    }
}