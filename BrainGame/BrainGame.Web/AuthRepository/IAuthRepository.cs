using System.Threading.Tasks;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.AuthRepository
{
    public interface IAuthRepository
    {
        Task<Register> Register(Register register);

        Task<User> Login(Login login);
    }
}