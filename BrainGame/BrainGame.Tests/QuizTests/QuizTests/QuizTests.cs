using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.QuizService;
using BrainGame.WebDb.QuizRepository.QuizRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.QuizTests.QuizTests
{
    public class QuizTests
    {
        private readonly Mock<IQuizRepository> _repository;

        public QuizTests()
        {
            _repository = new Mock<IQuizRepository>();
        }

        [Fact]
        public async Task GetAllQuizzes()
        {
            var quizzes = new List<Quizzes>
            {
                new()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new()
                {
                    Id = 2,
                    Name = "Plants"
                },
                new()
                {
                    Id = 3,
                    Name = "Mushrooms"
                }
            };

            _repository.Setup(_ => _.GetAllQuizzesAsync())
                .ReturnsAsync(quizzes);

            IQuizService service = new QuizService(_repository.Object);

            var result = await service.GetAllQuizzesAsync();

            _repository.Verify(_ => _.GetAllQuizzesAsync(),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(quizzes.Count, result.Count());
        }

        [Fact]
        public async Task CreateQuiz()
        {
            var quizModel = new Quizzes
            {
                Name = "NewQuiz"
            };

            _repository.Setup(_ => _.CreateQuizAsync(quizModel));

            IQuizService service = new QuizService(_repository.Object);

            await service.CreateQuizAsync(quizModel);

            _repository.Verify(_ => _.CreateQuizAsync(quizModel),
                Times.Once);
        }

        [Fact]
        public async Task UpdateQuiz()
        {
            var expectedId = 1;

            var quiz = new Quizzes
            {
                Id = expectedId,
                Name = "Animals"
            };

            var quizModel = new Quizzes
            {
                Name = "NewQuiz"
            };

            _repository.Setup(_ => _.GetQuizAsync(expectedId))
                .ReturnsAsync(quiz);

            _repository.Setup(_ => _.UpdateQuizAsync(quiz));

            IQuizService service = new QuizService(_repository.Object);

            await service.UpdateQuizAsync(quizModel, expectedId);

            _repository.Verify(_ => _.GetQuizAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UpdateQuizAsync(quiz),
                Times.Once);
        }

        [Fact]
        public async Task DeleteQuiz()
        {
            var expectedId = 1;

            var quiz = new Quizzes
            {
                Id = expectedId,
                Name = "Animals"
            };

            _repository.Setup(_ => _.GetQuizAsync(expectedId))
                .ReturnsAsync(quiz);

            _repository.Setup(_ => _.DeleteQuizAsync(quiz));

            IQuizService service = new QuizService(_repository.Object);

            await service.DeleteQuizAsync(expectedId);

            _repository.Verify(_ => _.GetQuizAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.DeleteQuizAsync(quiz),
                Times.Once);
        }
    }
}
