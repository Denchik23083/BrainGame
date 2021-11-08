using System;
using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
using BrainGame.Logic;
using Xunit;

namespace BrainGame.Tests
{
    public class BrainGameTest
    {
        private readonly BrainGameContext _context;

        public BrainGameTest(BrainGameContext context)
        {
            _context = context;
        }

        [Fact]
        public void Register()
        {
            var register = new Register
            {
                Name = "Ted",
                Email = "admin@gmail.com",
                Password = "0000",
                ConfirmPassword = "0000"
            };

            _context.Users.Add(Map(register));

            //Work
            /*_context.SaveChanges();*/

            var create = _context.Users.Count();

            Assert.Equal(2, create);
        }

        [Fact]
        public void Login()
        {
            var login = new Login
            {
                Email = "user@gmail.com",
                Password = "0000",
            };


            var user = _context.Users.FirstOrDefault(
                b => b.Email == login.Email &&
                     b.Password == login.Password);

            bool isUser;

            if (user is null)
            {
                isUser = false;
            }

            isUser = true;

            Assert.True(isUser);
        }

        [Fact]
        public void Get()
        {
            var user = Service._user;

            bool isUser;

            if (user is null)
            {
                isUser = false;
            }

            isUser = true;

            Assert.True(isUser);
        }

        [Fact]
        public void Update()
        {
            var newUser = new User
            {
                Name = "Bob",
                Email = "bob@gmail.com",
                Password = "0000"
            };
            
            var user = Service._user;

            if (user is null)
            {
                throw new ArgumentNullException();
            }

            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Password = newUser.Password;

            var update = _context.Users.Count();

            Assert.Equal(2, update);
        }

        [Fact]
        public void Delete()
        {
            var user = Service._user;
            if (user is null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(user);

            //Work
            /*_context.SaveChanges();*/

            var deleted = _context.Users.Count();

            Assert.Equal(1, deleted);
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
