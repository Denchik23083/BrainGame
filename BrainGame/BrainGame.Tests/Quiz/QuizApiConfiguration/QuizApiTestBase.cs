using BrainGame.Core.Utilities;
using BrainGame.Tests.Utilities;
using System.Net.Http.Headers;

namespace BrainGame.Tests.Quiz.QuizApiConfiguration
{
    public class QuizApiTestBase : AddTokenWithPermissions
    {
        protected readonly HttpClient HttpClient;

        public QuizApiTestBase()
        {
            var app = new QuizApiFactory();
            HttpClient = app.CreateDefaultClient();
        }

        protected void AddTokenWithPermissions(IEnumerable<PermissionType> permissions)
        {
            var user = UserWithPermissions(permissions);
            var token = GetUserToken(user);

            HttpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
