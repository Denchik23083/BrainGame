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

        Quizzes Quiz(Quizzes model);

        AnimalQuestions GetAnimalsQuestions(int id);

        PlantsQuestions GetPlantsQuestions(int id);

        MushroomsQuestions GetMushroomsQuestions(int id);

        Correct Correct();
    }
}
