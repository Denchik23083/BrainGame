using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Xunit;

namespace BrainGame.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Register_Test()
        {
            var context = new TestsBrainGameContext();

            var register = new Register
            {
                Name = "Nata",
                Email = "nata@gmail.com",
                Password = "0000",
                ConfirmPassword = "0000"
            };

            Assert.True(register.Password == register.ConfirmPassword);

            var user = Map(register);

            context.Users.Add(user);
            context.SaveChanges();

            var registeredUser = context.Users.FirstOrDefault(b => b.Email == user.Email 
                                                                   && b.Password == user.Password);
            Assert.NotNull(registeredUser);

            context.Users.Remove(registeredUser);
            context.SaveChanges();

            var registeredUserRemove = context.Users.FirstOrDefault(l => l.Email == registeredUser.Email &&
                                                                         l.Password == registeredUser.Password);
            Assert.Null(registeredUserRemove);
        }

        [Fact]
        public void Login_Test()
        {
            var context = new TestsBrainGameContext();

            var login = new Login
            {
                Email = "user@gmail.com",
                Password = "0000"
            };

            var user = Map(login);

            var loginUser = context.Users.FirstOrDefault(b => b.Email == user.Email
                                                              && b.Password == user.Password);

            Assert.NotNull(loginUser);
        }

        private User Map(Register model)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }

        private User Map(Login model)
        {
            return new User
            {
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
