using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.WebDb.QuizRepository.StatisticsRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.QuizTests.StatisticsTests
{
    public class StatisticsTests
    {
        private readonly Mock<IStatisticsRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;

        public StatisticsTests()
        {
            _repository = new Mock<IStatisticsRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetAllStatistics()
        {
            var expectedId = 1;

            var statistics = new List<Statistics>
            {
                new()
                {
                    Id = 1,
                    Point = 2,
                    QuizId = 1,
                    UserId = expectedId
                }
            };

            _repository.Setup(_ => _.GetAllStatisticsAsync(expectedId))
                .ReturnsAsync(statistics);

            IStatisticsService service = new StatisticsService(_repository.Object, _userRepository.Object);

            var result = await service.GetAllStatisticsAsync(expectedId);

            _repository.Verify(_ => _.GetAllStatisticsAsync(expectedId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(statistics.Count, result.Count());
        }

        [Fact]
        public async Task CreateSession()
        {
            var expectedId = 1;

            var quizId = 1;

            var user = new User
            {
                Id = expectedId,
                Name = "Anna",
                Email = "user@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3,
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            IStatisticsService service = new StatisticsService(_repository.Object, _userRepository.Object);

            await service.CreateSessionAsync(quizId, expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);
        }

        [Fact]
        public async Task AddPoint()
        {
            var expectedId = 1;

            var quizId = 1;

            var user = new User
            {
                Id = expectedId,
                Name = "Anna",
                Email = "user@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3,
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            IStatisticsService service = new StatisticsService(_repository.Object, _userRepository.Object);

            await service.AddPointAsync(quizId, expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);
        }

        [Fact]
        public async Task GetPoints()
        {
            var expectedId = 1;

            var quizId = 1;

            var user = new User
            {
                Id = expectedId,
                Name = "Anna",
                Email = "user@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3,
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.SavePointsAsync(It.IsAny<Statistics>()));

            IStatisticsService service = new StatisticsService(_repository.Object, _userRepository.Object);

            await service.GetPointsAsync(quizId, expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.SavePointsAsync(It.IsAny<Statistics>()),
                Times.Once);
        }

        [Fact]
        public async Task ResetStatistics()
        {
            var expectedId = 1;

            var user = new User
            {
                Id = expectedId,
                Name = "Anna",
                Email = "user@gmail.com",
                Password = "0000",
                GenderId = 2,
                RoleId = 3,
            };

            var statistics = new List<Statistics>
            {
                new()
                {
                    Id = 1,
                    Point = 2,
                    QuizId = 1,
                    UserId = expectedId
                }
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.GetAllStatisticsAsync(expectedId))
                .ReturnsAsync(statistics);

            _repository.Setup(_ => _.ResetStatisticsAsync(statistics));

            IStatisticsService service = new StatisticsService(_repository.Object, _userRepository.Object);

            await service.ResetStatisticsAsync(expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.GetAllStatisticsAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.ResetStatisticsAsync(statistics),
                Times.Once);
        }
    }
}
