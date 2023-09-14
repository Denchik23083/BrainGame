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

        public async Task RegisterAsync(User register)
        {
            await _context.Users.AddAsync(register);

            await _context.SaveChangesAsync();
        }

        public async Task<User?> LoginAsync(User login)
        {
            return await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);
        }

        public async Task<RefreshToken?> RefreshAsync(RefreshToken refresh)
        {
            return await _context.RefreshTokens
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Role)
                .ThenInclude(_ => _!.RolePermissions)
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(_ => _.Value == refresh.Value);
        }

        public async Task CreateRefreshTokenAsync(User user)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRefreshTokenAsync(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}