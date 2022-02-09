using System.Threading.Tasks;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.AuthService
{
    public interface IAuthService
    {
        Task<Register> Register(Register register);

        Task<User> Login(Login login);
    }
}