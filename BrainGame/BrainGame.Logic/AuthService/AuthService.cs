using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.AuthRepository;

namespace BrainGame.Logic.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterAsync(User register)
        {
            register.RoleId = 3;

            await _repository.RegisterAsync(register);
        }

        public async Task<User> LoginAsync(User login)
        { 
            var user = await _repository.LoginAsync(login);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        public async Task<User> RefreshAsync(RefreshToken refresh)
        {
            var refreshToken = await _repository.RefreshAsync(refresh);

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

        public async Task CreateRefreshTokenAsync(Guid refreshToken, User user)
        {
            user.RefreshToken = new RefreshToken { Value = refreshToken };

            await _repository.CreateRefreshTokenAsync(user);
        }

        public async Task UpdateRefreshTokenAsync(Guid refreshToken, User user)
        {
            user.RefreshToken!.Value = refreshToken;

            await _repository.UpdateRefreshTokenAsync(user);
        }
    }
}