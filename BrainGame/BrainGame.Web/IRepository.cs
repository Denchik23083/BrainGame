using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IRepository
    {
        Register Register(Register register);

        User Login(Login login);

        User User();

        void Update(User user);

        void Remove();
    }
}
