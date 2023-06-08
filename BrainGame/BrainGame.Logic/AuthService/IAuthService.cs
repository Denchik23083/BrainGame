using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.AuthService
{
    public interface IAuthService
    {
        Task<User> Register(Register register);

        Task<User> Login(Login login);
    }
}