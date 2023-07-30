using System.Net;
using System.Net.Http.Json;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Quiz;
using BrainGame.Quiz.Models;
using BrainGame.Tests.Quiz.QuizApiConfiguration;
using Newtonsoft.Json;
using Xunit;

namespace BrainGame.Tests.Quiz.QuizTests
{
    public class QuestionTests : QuizApiTestBase
    {
        [Fact]
        public async Task GetQuestions()
        {
            AddTokenWithPermissions(new List<PermissionType>
                { PermissionType.GetQuiz });

            var quizId = 1;

            var expectedCount = 2;

            var response = await HttpClient.GetAsync($"api/question/id?id={quizId}");

            var body = await response.Content.ReadAsStringAsync();

            var questions = JsonConvert.DeserializeObject<IEnumerable<QuestionReadModel>>(body);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(questions);
            Assert.Equal(expectedCount, questions.Count());
        }

        [Fact]
        public async Task CreateQuestion()
        {
            AddTokenWithPermissions(new List<PermissionType>
                { PermissionType.EditQuiz });

            var newQuestion = new QuestionWriteModel
            {
                Number = 3,
                Question = "Foo",
                Answers = "Too,Boo,Goo",
                QuizId = 1,
                Correct = new Correct { CorrectAnswer = "Too" }
            };

            var content = JsonContent.Create(newQuestion);

            var response = await HttpClient.PostAsync("api/question", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task UpdateQuestion()
        {
            AddTokenWithPermissions(new List<PermissionType>
                { PermissionType.EditQuiz });

            var expectedId = 11;

            var editQuestion = new QuestionWriteModel
            {
                Number = 3,
                Question = "Foo",
                Answers = "Too,Boo,Goo",
                QuizId = 1,
                Correct = new Correct { CorrectAnswer = "Boo" }
            };

            var content = JsonContent.Create(editQuestion);

            var response = await HttpClient.PutAsync($"api/question/id?id={expectedId}", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteQuestion()
        {
            AddTokenWithPermissions(new List<PermissionType>
                { PermissionType.EditQuiz });

            var expectedId = 11;

            var response = await HttpClient.DeleteAsync($"api/question/id?id={expectedId}");

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
