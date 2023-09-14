using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using BrainGame.WebDb.AuthRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.AuthTests
{
    public class AuthTests
    {
        private readonly Mock<IAuthRepository> _repository;

        public AuthTests()
        {
            _repository = new Mock<IAuthRepository>();
        }

        [Fact]
        public async Task Register()
        {
            var userModel = new User
            {
                Name = "newUser",
                Email = "newEmail@gmail.com",
                Password = "0000",
                GenderId = 1
            };

            _repository.Setup(_ => _.RegisterAsync(userModel));

            IAuthService service = new AuthService(_repository.Object);

            await service.RegisterAsync(userModel);

            _repository.Verify(_ => _.RegisterAsync(userModel),
                Times.Once);
        }
    }
}
