using BrainGame.Core.Exceptions;
using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly BrainGameContext _context;

        public UserRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string userEmail)
        {
            var user = await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b => b.Email == userEmail);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task EditUser(User userToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task EditPassword(User userToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUser(User userToRemove)
        {
            _context.Users.Remove(userToRemove);
            _context.RefreshTokens.Remove(userToRemove.RefreshToken!);

            await _context.SaveChangesAsync();
        }
    }
}