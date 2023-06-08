using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.AuthRepository
{
    public interface IAuthRepository
    {
        Task<User> Register(User register);

        Task<User> Login(User login);
    }
}