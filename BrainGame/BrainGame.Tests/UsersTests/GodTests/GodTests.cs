using BrainGame.Db.Entities.Auth;
using BrainGame.Logic.UsersService.GodService;
using BrainGame.Tests.Utilities;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.GodRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.UsersTests.GodTests
{
    public class GodTests : AuthUser
    {
        private readonly Mock<IGodRepository> _repository;
        private readonly Mock<IAdminRepository> _adminRepository;
        private readonly Mock<IUserRepository> _userRepository;

        public GodTests()
        {
            _repository = new Mock<IGodRepository>();
            _adminRepository = new Mock<IAdminRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task UserToAdmin()
        {
            var expectedId = 4;

            var userToAdmin = new User
            {
                Id = expectedId,
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(userToAdmin);

            _repository.Setup(_ => _.UserToAdminAsync(userToAdmin));

            IGodService service = new GodService(_repository.Object, _adminRepository.Object, _userRepository.Object);

            await service.UserToAdminAsync(expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UserToAdminAsync(userToAdmin),
                Times.Once);
        }

        [Fact]
        public async Task AdminToUser()
        {
            var expectedId = 5;

            var adminToUser = new User
            {
                Id = expectedId,
                Name = "Test",
                Email = "Test@gmail.com",
                Password = "0000",
                GenderId = 1,
                RoleId = 2
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(adminToUser);

            _repository.Setup(_ => _.UserToAdminAsync(adminToUser));

            IGodService service = new GodService(_repository.Object, _adminRepository.Object, _userRepository.Object);

            await service.UserToAdminAsync(expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UserToAdminAsync(adminToUser),
                Times.Once);
        }
    }
}
