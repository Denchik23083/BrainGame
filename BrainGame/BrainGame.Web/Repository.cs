using System;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public class Repository : IRepository
    {
        private readonly BrainGameContext _context;

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

        public Quiz Get(int id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);

            return quiz;
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
