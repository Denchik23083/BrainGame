using System;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public class Repository : IRepository
    {
        private readonly BrainGameContext _context;
        private static User _user;

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

            _user = user;

            return user;
        }

        public User User()
        {
            var user = _user;
            return user;
        }

        public void Update(User user)
        {
            var id = _user.Id;
            var userToUpdate = _context.Users.FirstOrDefault(b => b.Id == id);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            _context.SaveChanges();
        }

        public void Remove()
        {
            var id = _user.Id;

            var userToRemove = _context.Users.FirstOrDefault(b => b.Id == id);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(userToRemove);
            _context.SaveChanges();
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
