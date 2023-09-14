using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.UsersService.AdminService;
using BrainGame.Tests.Utilities;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.UsersTests.AdminTests
{
    public class AdminTests : AuthUser
    {
        private readonly Mock<IAdminRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;

        public AdminTests()
        {
            _repository = new Mock<IAdminRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetAdmins()
        {
            var roleId = 2;

            var admins = new List<User>
            {
                new()
                {
                    Id = 2,
                    Name = "Ted",
                    Email = "admin@gmail.com",
                    Password = "0000",
                    GenderId = 1,
                    RoleId = roleId,
                }
            };

            _repository.Setup(_ => _.GetAllAdminsAsync(roleId))
                .ReturnsAsync(admins);

            IAdminService service = new AdminService(_repository.Object, _userRepository.Object);

            var result = await service.GetAllAdminsAsync();

            _repository.Verify(_ => _.GetAllAdminsAsync(roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(admins.Count, result.Count());
        }

        [Fact]
        public async Task RemoveUser()
        {
            var expectedId = 4;

            var user = new User
            {
                Id = expectedId,
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.RemoveUserAsync(user));

            IAdminService service = new AdminService(_repository.Object, _userRepository.Object);

            await service.RemoveUserAsync(expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.RemoveUserAsync(user),
                Times.Once);
        }
    }
}
