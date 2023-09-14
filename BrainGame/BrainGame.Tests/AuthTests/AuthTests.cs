using BrainGame.Auth.Models;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.AuthService;
using BrainGame.Tests.Utilities;
using BrainGame.WebDb.AuthRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.AuthTests
{
    public class AuthTests : AuthUser
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

        [Fact]
        public async Task Login()
        {
            var userModel = new User
            {
                Email = "user@gmail.com",
                Password = "0000"
            };

            var user = User();

            _repository.Setup(_ => _.LoginAsync(userModel))
                .ReturnsAsync(user);

            IAuthService service = new AuthService(_repository.Object);

            var result = await service.LoginAsync(userModel);

            _repository.Verify(_ => _.LoginAsync(userModel),
                Times.Once);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Refresh()
        {
            var user = User();

            var refreshTokenModel = new RefreshToken
            {
                Value = new Guid(),
                UserId = user.Id
            };

            var refreshToken = new RefreshToken
            {
                Value = new Guid(),
                UserId = user.Id,
                User = user
            };

            _repository.Setup(_ => _.RefreshAsync(refreshTokenModel))
                .ReturnsAsync(refreshToken);

            IAuthService service = new AuthService(_repository.Object);

            var result = await service.RefreshAsync(refreshTokenModel);

            _repository.Verify(_ => _.RefreshAsync(refreshTokenModel),
                Times.Once);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task CreateRefreshToken()
        {
            var user = User();

            var refreshToken = new Guid();

            user.RefreshToken = new RefreshToken
            {
                Value = refreshToken
            };

            _repository.Setup(_ => _.CreateRefreshTokenAsync(It.IsAny<User>()));

            IAuthService service = new AuthService(_repository.Object);

            await service.CreateRefreshTokenAsync(refreshToken, user);

            _repository.Verify(_ => _.CreateRefreshTokenAsync(It.IsAny<User>()),
                Times.Once);
        }

        [Fact]
        public async Task UpdateRefreshToken()
        {
            var user = User();

            var refreshToken = new Guid();

            user.RefreshToken = new RefreshToken
            {
                Value = refreshToken
            };

            user.RefreshToken!.Value = refreshToken;

            _repository.Setup(_ => _.UpdateRefreshTokenAsync(It.IsAny<User>()));

            IAuthService service = new AuthService(_repository.Object);

            await service.UpdateRefreshTokenAsync(refreshToken, user);

            _repository.Verify(_ => _.UpdateRefreshTokenAsync(It.IsAny<User>()),
                Times.Once);
        }
    }
}
