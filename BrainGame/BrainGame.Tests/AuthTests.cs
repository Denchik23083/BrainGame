using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Xunit;

namespace BrainGame.Tests
{
    public class AuthTests
    {
        private readonly BrainGameContext _context;

        public AuthTests(BrainGameContext context)
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
            
            _context.SaveChanges();

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
            
            Assert.NotNull(user);

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
