using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.CorrectService;
using BrainGame.WebDb.QuizRepository.CorrectRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.QuizTests.CorrectTests
{
    public class CorrectTests
    {
        private readonly Mock<ICorrectRepository> _repository;

        public CorrectTests()
        {
            _repository = new Mock<ICorrectRepository>();
        }

        [Fact]
        public async Task Correct()
        {
            var correct = new Correct
            {
                Id = 4,
                CorrectAnswer = "Арахис",
                QuestionId = 5
            };

            var correctModel = new Correct
            {
                CorrectAnswer = "Арахис",
                QuestionId = 5
            };

            _repository.Setup(_ => _.CorrectAsync(correctModel.QuestionId))
                .ReturnsAsync(correct);

            ICorrectService service = new CorrectService(_repository.Object);

            var result = await service.CorrectAsync(correctModel);

            _repository.Verify(_ => _.CorrectAsync(correctModel.QuestionId),
                Times.Once);

            Assert.True(result);
        }
    }
}
