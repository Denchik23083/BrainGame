using System;
using System.Threading.Tasks;
using BrainGame.Db.Entities;
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

        public async Task<Register> Register(Register register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                throw new ArgumentException();
            }

            return await _repository.Register(register);
        }

        public async Task<User> Login(Login login)
        {
            var user = await _repository.Login(login);

            if (user is null)
            {
                return null;
            }

            User = user;

            return user;
        }
    }
}