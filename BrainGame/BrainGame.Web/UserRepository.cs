using System;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb
{
    public class UserRepository : IUserRepository
    {
        private readonly BrainGameContext _context;

        public UserRepository(BrainGameContext context)
        {
            _context = context;
        }

        public User Get(User user)
        {
            return user;
        }

        public async Task<User> Update(User user)
        {
            var id = user.Id;
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);

            return userToUpdate;
        }

        public async Task Remove(int id)
        {
            var userToRemove = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(userToRemove);
            await _context.SaveChangesAsync();
        }
    }
}