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

        Quiz Quiz(Quiz model);

        Questions GetQuestion(int id);

        void Correct(int answerId);
    }
}
