using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.AuthRepository;

namespace BrainGame.Logic.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public static User User = null!;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Register(User register)
        {
            return await _repository.Register(register);
        }

        public async Task<User> Login(User login)
        {
            return await _repository.Login(login);
        }
    }
}