using BrainGame.Core.Exceptions;
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

        public async Task Register(User register)
        {
            await _context.Users.AddAsync(register);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Login(User login)
        {
            var user = await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        public async Task<User> RefreshLogin(Guid value)
        {
            var refreshToken = await _context.RefreshTokens
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(_ => _.Value == value);

            if (refreshToken is null)
            {
                throw new RefreshTokenNotFoundException("RefreshToken not found");
            }

            if (refreshToken.User is null)
            {
                throw new UserNotFoundException("User with this refreshToken not found");
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