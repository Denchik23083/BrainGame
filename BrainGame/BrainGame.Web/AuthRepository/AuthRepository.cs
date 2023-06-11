using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BrainGameContext _context;

        public AuthRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User register)
        {
            await _context.Users.AddAsync(register);
            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<User> Login(User login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            if (user is null)
            {
                throw new ArgumentException(nameof(user));
            }

            return user;
        }
    }
}