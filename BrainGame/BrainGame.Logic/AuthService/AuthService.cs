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

        public async Task Register(User register)
        {
            await _repository.Register(register);
        }

        public async Task<User> Login(User login)
        {
            return await _repository.Login(login);
        }

        public async Task<User> RefreshLogin(Guid value)
        {
            return await _repository.RefreshLogin(value);
        }

        public async Task CreateRefreshToken(Guid refreshToken, User user)
        {
            await _repository.CreateRefreshToken(refreshToken, user);
        }

        public async Task UpdateRefreshToken(Guid refreshToken, User user)
        {
            await _repository.UpdateRefreshToken(refreshToken, user);
        }
    }
}