using System.Threading.Tasks;
using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.AuthRepository;

namespace BrainGame.Logic.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public static User User;

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
            var user = await _repository.Login(Map(login));

            if (user is null)
            {
                return null;
            }

            User = user;

            return user;
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