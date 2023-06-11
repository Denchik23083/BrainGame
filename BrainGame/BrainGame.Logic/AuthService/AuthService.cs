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

        public async Task<User> Register(Register register)
        {
            return await _repository.Register(Map(register));
        }

        public async Task<User> Login(Login login)
        {
            return await _repository.Login(Map(login));
        }

        private User Map(Login model)
        {
            return new User
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
            };
        }

        private User Map(Register model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}