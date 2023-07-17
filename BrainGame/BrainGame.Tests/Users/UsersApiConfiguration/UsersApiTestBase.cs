using BrainGame.Core.Utilities;
using BrainGame.Tests.Utilities;
using System.Net.Http.Headers;

namespace BrainGame.Tests.Users.UsersApiConfiguration
{
    public class UsersApiTestBase : AddTokenWithPermissions
    {
        protected readonly HttpClient HttpClient;

        public UsersApiTestBase()
        {
            var app = new UsersApiFactory();
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
