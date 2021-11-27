using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;

namespace BrainGame.Logic
{
    public interface IService
    {
        Register Register(Register register);

        User Login(Login login);

        User User();

        void Update(User user);

        void Remove();

        Quizzes Quiz(Quizzes model);

        AnimalQuestions GetAnimalsQuestions(int id);

        PlantsQuestions GetPlantsQuestions(int id);

        MushroomsQuestions GetMushroomsQuestions(int id);

        void Correct(Correct correctAnswerUser);
    }
}
