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
                .Include(_ => _.RefreshToken)
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            if (user is null)
            {
                throw new ArgumentException(nameof(user));
            }

            return user;
        }

        public async Task<User> RefreshLogin(Guid value)
        {
            var refreshToken = await _context.RefreshTokens
                .Include(_ => _.User)
                .FirstOrDefaultAsync(_ => _.Value == value);

            if (refreshToken is null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }

            if (refreshToken.User is null)
            {
                throw new ArgumentNullException(nameof(refreshToken.User));
            }

            return refreshToken.User;
        }

        public async Task CreateRefreshToken(Guid refreshToken, User user)
        {
            user.RefreshToken = new RefreshToken { Value = refreshToken };
            
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRefreshToken(Guid refreshToken, User user)
        {
            user.RefreshToken!.Value = refreshToken;

            await _context.SaveChangesAsync();
        }
    }
}