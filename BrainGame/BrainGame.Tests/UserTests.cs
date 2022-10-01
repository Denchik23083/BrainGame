using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities.Auth;
using Xunit;

namespace BrainGame.Tests
{
    public class UserTests
    {
        [Fact]
        public void Get_Test()
        {
            var context = new TestsBrainGameContext();
            var id = 1;

            var user = context.Users.FirstOrDefault(b => b.Id == id);

            Assert.NotNull(user);
            Assert.Equal(id, user.Id);
        }

        [Fact]
        public void Update_Test()
        {
            var context = new TestsBrainGameContext();

            var newUser = new User
            {
                Name = "Tests",
                Email = "Tests@gmail.com",
                Password = "0000"
            };

            var updatesUser = new User
            {
                Name = "Fil",
                Email = "newEmail@gmail.com"
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            var user = context.Users.FirstOrDefault(b => b.Email == newUser.Email
                                                                   && b.Password == newUser.Password);
            Assert.NotNull(user);

            user.Name = updatesUser.Name;
            user.Email = updatesUser.Email;

            context.SaveChanges();

            var updatedUser = context.Users.FirstOrDefault(b => b.Email == updatesUser.Email
                                                         && b.Password == user.Password);
            Assert.NotNull(updatedUser);
            
            context.Users.Remove(updatedUser);
            context.SaveChanges();

            var updatedUserRemove = context.Users.FirstOrDefault(l => l.Email == updatedUser.Email &&
                                                                         l.Password == updatedUser.Password);
            Assert.Null(updatedUserRemove);
        }

        [Fact]
        public void Remove_Test()
        {
            var context = new TestsBrainGameContext();

            var newUser = new User
            {
                Name = "Tests23",
                Email = "Tests23@gmail.com",
                Password = "1111"
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            var user = context.Users.FirstOrDefault(b => b.Email == newUser.Email
                                                         && b.Password == newUser.Password);
            Assert.NotNull(user);

            context.Users.Remove(user);
            context.SaveChanges();

            var updatedUserRemove = context.Users.FirstOrDefault(l => l.Email == user.Email &&
                                                                      l.Password == user.Password);
            Assert.Null(updatedUserRemove);
        }

        [Fact]
        public void Password_Test()
        {
            var context = new TestsBrainGameContext();

            var newUser = new User
            {
                Name = "Tests",
                Email = "Tests@gmail.com",
                Password = "0000"
            };

            var updatesPasswordUser = new Register
            {
                Password = "1111",
                ConfirmPassword = "1111"
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            var user = context.Users.FirstOrDefault(b => b.Email == newUser.Email
                                                         && b.Password == newUser.Password);
            Assert.NotNull(user);

            Assert.True(updatesPasswordUser.Password == updatesPasswordUser.ConfirmPassword);

            user.Password = updatesPasswordUser.Password;

            context.SaveChanges();

            var updatedUser = context.Users.FirstOrDefault(b => b.Email == newUser.Email
                                                                && b.Password == updatesPasswordUser.Password);
            Assert.NotNull(updatedUser);

            context.Users.Remove(updatedUser);
            context.SaveChanges();

            var updatedUserRemove = context.Users.FirstOrDefault(l => l.Email == updatedUser.Email &&
                                                                      l.Password == updatedUser.Password);
            Assert.Null(updatedUserRemove);
        }
    }
}
