using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.AuthService
{
    public interface IAuthService
    {
        Task<User> Register(User register);

        Task<User> Login(User login);
    }
}