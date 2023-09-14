using BrainGame.Db.Entities.Auth;

namespace BrainGame.Tests.Utilities
{
    public class AuthUser
    {
        protected static User User()
        {
            return new User
            {
                Id = 3,
                Name = "Anna",
                Email = "user@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3
            };
        }
    }
}
