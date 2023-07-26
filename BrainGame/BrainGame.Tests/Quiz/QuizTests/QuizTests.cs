using BrainGame.Core.Utilities;
using BrainGame.Quiz.Models;
using BrainGame.Tests.Quiz.QuizApiConfiguration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BrainGame.Tests.Quiz.QuizTests
{
    public class QuizTests : QuizApiTestBase
    {
        [Fact]
        public async Task GetQuizzes()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.GetQuiz });

            var expectedCount = 3;

            var response = await HttpClient.GetAsync("api/quiz");

            var body = await response.Content.ReadAsStringAsync();

            var quizzes = JsonConvert.DeserializeObject<IEnumerable<QuizReadModel>>(body);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(quizzes);
            Assert.Equal(expectedCount, quizzes.Count());
        }

        [Fact]
        public async Task CreateQuiz()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.EditQuiz });

            var newQuiz = new QuizWriteModel
            {
                Name = "Foo"
            };

            var content = JsonContent.Create(newQuiz);

            var response = await HttpClient.PostAsync("api/quiz", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task UpdateQuiz()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.EditQuiz });

            var expectedId = 4;

            var editQuiz = new QuizWriteModel
            {
                Name = "Too"
            };

            var content = JsonContent.Create(editQuiz);

            var response = await HttpClient.PutAsync($"api/quiz/id?id={expectedId}", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteQuiz()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.EditQuiz });

            var expectedId = 4;

            var response = await HttpClient.DeleteAsync($"api/quiz/id?id={expectedId}");

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
