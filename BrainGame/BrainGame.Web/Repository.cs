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
            if (register.Password != register.ConfirmPassword)
            {
                throw new ArgumentException();
            }

            _context.Users.Add(Map(register));
            _context.SaveChanges();

            return register;
        }

        public User Login(Login login)
        {
            var user = _context.Users.FirstOrDefault(
                b => b.Email == login.Email && 
                         b.Password == login.Password);

            if (user is null)
            {
                return null;
            }

            return user;
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
