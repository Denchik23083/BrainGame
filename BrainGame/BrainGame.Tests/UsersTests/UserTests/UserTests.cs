using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.Tests.Utilities;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.UsersTests.UserTests
{
    public class UserTests : AuthUser
    {
        private readonly Mock<IUserRepository> _repository;

        public UserTests()
        {
            _repository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetUsers()
        {
            var roleId = 3;

            var users = new List<User>
            {
                new()
                {
                    Id = 3,
                    Name = "Anna",
                    Email = "user@gmail.com",
                    Password = "0000",
                    GenderId = 2,
                    RoleId = roleId,
                }
            };

            _repository.Setup(_ => _.GetUsersAsync(roleId))
                .ReturnsAsync(users);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetUsersAsync();

            _repository.Verify(_ => _.GetUsersAsync(roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count());
        }

        [Fact]
        public async Task GetGenders()
        {
            var genders = new List<Gender>
            {
                new() { Id = 1, Type = GenderType.Male },
                new() { Id = 2, Type = GenderType.Female }
            };

            _repository.Setup(_ => _.GetGendersAsync())
                .ReturnsAsync(genders);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetGendersAsync();

            _repository.Verify(_ => _.GetGendersAsync(),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(genders.Count, result.Count());
        }

        [Fact]
        public async Task EditUser()
        {
            var user = User();

            var expectedId = 3;

            var userModel = new User
            {
                Name = "EditName",
                Email = "EditEmail@gmail.com"
            };

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.EditUserAsync(user));

            IUserService service = new UserService(_repository.Object);

            await service.EditUserAsync(userModel, expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.EditUserAsync(user),
                Times.Once);
        }

        [Fact]
        public async Task EditPassword()
        {
            var user = User();

            var expectedId = 3;

            var passwordModel = new Password
            {
                OldPassword = "0000",
                NewPassword = "1111",
                ConfirmPassword = "1111",
            };

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.EditPasswordAsync(user));

            IUserService service = new UserService(_repository.Object);

            await service.EditPasswordAsync(passwordModel, expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.EditPasswordAsync(user),
                Times.Once);
        }
    }
}
