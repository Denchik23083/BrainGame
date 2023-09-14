using BrainGame.Db.Entities.Quiz;
using BrainGame.Logic.QuizService.QuestionService;
using BrainGame.Logic.QuizService.QuizService;
using BrainGame.WebDb.QuizRepository.QuestionRepository;
using Moq;
using Xunit;

namespace BrainGame.Tests.QuizTests.QuestionTests
{
    public class QuestionTests
    {
        private readonly Mock<IQuestionRepository> _repository;

        public QuestionTests()
        {
            _repository = new Mock<IQuestionRepository>();
        }

        [Fact]
        public async Task GetAllQuestions()
        {
            var quizId = 1;

            var questions = new List<Questions>
            {
                new()
                {
                    Id = 1,
                    Number = 1,
                    Question = "Кто гавкает?",
                    Answers = "Собака,Кошка,Хомяк",
                    QuizId = quizId
                },
                new()
                {
                    Id = 3,
                    Number = 2,
                    Question = "Какая птица не умеет летать?",
                    Answers = "Орел,Пингвин,Ворон",
                    QuizId = quizId
                }
            };

            _repository.Setup(_ => _.GetAllQuestionsAsync(quizId))
                .ReturnsAsync(questions);

            IQuestionService service = new QuestionService(_repository.Object);

            var result = await service.GetAllQuestionsAsync(quizId);

            _repository.Verify(_ => _.GetAllQuestionsAsync(quizId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(questions.Count, result.Count());
        }

        [Fact]
        public async Task CreateQuestion()
        {
            var questionModel = new Questions
            {
                Number = 3,
                Question = "dsds",
                Answers = "r,t,y",
                Correct = new Correct { CorrectAnswer = "t" },
                QuizId = 1
            };

            _repository.Setup(_ => _.CreateQuestionAsync(questionModel));

            IQuestionService service = new QuestionService(_repository.Object);

            await service.CreateQuestionAsync(questionModel);

            _repository.Verify(_ => _.CreateQuestionAsync(questionModel),
                Times.Once);
        }

        [Fact]
        public async Task UpdateQuestion()
        {
            var expectedId = 3;

            var question = new Questions
            {
                Id = expectedId,
                Number = 3,
                Question = "dsds",
                Answers = "y,u,i",
                Correct = new Correct { CorrectAnswer = "u" },
                QuizId = 1
            };

            var questionModel = new Questions
            {
                Number = 3,
                Question = "dsds",
                Answers = "r,t,y",
                Correct = new Correct { CorrectAnswer = "t" },
            };

            _repository.Setup(_ => _.GetQuestionAsync(expectedId))
                .ReturnsAsync(question);

            _repository.Setup(_ => _.UpdateQuestionAsync(question));

            IQuestionService service = new QuestionService(_repository.Object);

            await service.UpdateQuestionAsync(questionModel, expectedId);

            _repository.Verify(_ => _.GetQuestionAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UpdateQuestionAsync(question),
                Times.Once);
        }

        [Fact]
        public async Task DeleteQuestion()
        {
            var expectedId = 3;

            var question = new Questions
            {
                Id = expectedId,
                Number = 3,
                Question = "dsds",
                Answers = "y,u,i",
                Correct = new Correct { CorrectAnswer = "u" },
                QuizId = 1
            };

            _repository.Setup(_ => _.GetQuestionAsync(expectedId))
                .ReturnsAsync(question);

            _repository.Setup(_ => _.DeleteQuestionAsync(question));

            IQuestionService service = new QuestionService(_repository.Object);

            await service.DeleteQuestionAsync(expectedId);

            _repository.Verify(_ => _.GetQuestionAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.DeleteQuestionAsync(question),
                Times.Once);
        }
    }
}
