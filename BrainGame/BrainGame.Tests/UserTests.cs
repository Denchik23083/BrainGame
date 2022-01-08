using BrainGame.Db.Entities;
using BrainGame.Logic;
using Xunit;

namespace BrainGame.Tests
{
    public class UserTests
    {        
        [Fact]
        public void Get()
        {
            var expectedUser = new User
            {
                Email = "user@gmail.com",
                Password = "0000",
            };

            var user = AuthService._user;

            Assert.True(expectedUser.Email == user.Email && 
                        expectedUser.Password == user.Password);
        }
    }
}
