using System.Threading.Tasks;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.Logic.AuthService
{
    public interface IUserService
    {
        User Get();

        Task Update(User user);

        Task Remove();

        Task Password(Password model);
    }
}