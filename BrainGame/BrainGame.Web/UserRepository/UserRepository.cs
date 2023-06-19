using BrainGame.Core.Utilities;
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

        public async Task<User> GetUser(User? user)
        {
            return (await _context.Users.FirstOrDefaultAsync(b => b.Id == user!.Id))!;
        }

        public async Task Update(User userToUpdate, User user)
        {
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            await _context.SaveChangesAsync();
        }

        public async Task Remove(User userToRemove)
        {
            _context.Users.Remove(userToRemove);

            await _context.SaveChangesAsync();
        }

        public async Task Password(User userToUpdate, Password model)
        {
            userToUpdate.Password = model.NewPassword;

            await _context.SaveChangesAsync();
        }
    }
}