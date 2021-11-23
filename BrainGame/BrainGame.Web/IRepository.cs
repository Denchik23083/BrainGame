using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public interface IRepository
    {
        Register Register(Register register);

        User Login(Login login);

        User User(User user);

        User Update(User user);

        void Remove(int id);

        Quizes Quiz(Quizes model);

        Questions GetQuestion(int id);

        Correct Correct();
    }
}
