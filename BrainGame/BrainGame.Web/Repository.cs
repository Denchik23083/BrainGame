using System;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace BrainGame.WebDb
{
    public class Repository : IRepository
    {
        private readonly BrainGameContext _context;
        private static int? _id;

        public Repository(BrainGameContext context)
        {
            _context = context;
        }

        public Register Register(Register register)
        {
            _context.Users.Add(Map(register));
            _context.SaveChanges();

            return register;
        }

        public User Login(Login login)
        {
            var user = _context.Users
                .FirstOrDefault(b =>
                b.Email == login.Email && 
                b.Password == login.Password);

            return user;
        }

        public User User(User user)
        {
            return user;
        }

        public User Update(User user)
        {
            var id = user.Id;
            var userToUpdate = _context.Users.FirstOrDefault(b => b.Id == id);
            return userToUpdate;
        }

        public void Remove(int id)
        {
            var userToRemove = _context.Users.FirstOrDefault(b => b.Id == id);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(userToRemove);
            _context.SaveChanges();
        }

        public Quiz GetQuestion(int id)
        {
            var question = _context.Quizzes.FirstOrDefault(q => q.Id == id);

            _id = question?.CorrectAnswerId;

            return question;
        }

        public Correct Correct()
        {
            var correct = _context.Corrects.FirstOrDefault(a => a.Id == _id);

            return correct;
        }

        private User Map(Register model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
