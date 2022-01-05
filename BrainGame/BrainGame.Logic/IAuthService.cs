using System.Threading.Tasks;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IAuthService
    {
        Task<Register> Register(Register register);

        Task<User> Login(Login login);
    }
}
