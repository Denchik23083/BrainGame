using BrainGame.Core.Utilities;
using BrainGame.Tests.Users.UsersApiConfiguration;
using System.Net;
using Xunit;

namespace BrainGame.Tests.Users.UsersTests
{
    public class GodTests : UsersApiTestBase
    {
        [Fact]
        public async Task UserToAdmin()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.UserToAdmin });

            var expectedId = 3;

            var response = await HttpClient.PutAsync($"api/god/usertoadmin/id?id={expectedId}", null);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task AdminToUser()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.AdminToUser });

            var expectedId = 3;

            var response = await HttpClient.PutAsync($"api/god/admintouser/id?id={expectedId}", null);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
