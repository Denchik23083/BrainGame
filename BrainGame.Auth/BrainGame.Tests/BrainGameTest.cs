using System.Linq;
using BrainGame.Db;
using BrainGame.Db.Entities;
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
               Login = "admin@gmail.com",
               Password = "0000",
               ConfirmPassword = "0000"
            };

            _context.Registers.Add(register);

            //Work
            /*_context.SaveChanges();*/

            var create = _context.Registers.Count();

            Assert.Equal(2, create);
        }
    }
}
