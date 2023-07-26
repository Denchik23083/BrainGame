using BrainGame.Core.Utilities;
using BrainGame.Tests.Users.UsersApiConfiguration;
using BrainGame.Users.Models;
using Newtonsoft.Json;
using System.Net;
using Xunit;

namespace BrainGame.Tests.Users.UsersTests
{
    public class AdminTests : UsersApiTestBase
    {
        [Fact]
        public async Task GetAdmins()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.AdminToUser });

            var expectedCount = 1;

            var response = await HttpClient.GetAsync("api/admin");

            var body = await response.Content.ReadAsStringAsync();

            var admins = JsonConvert.DeserializeObject<IEnumerable<AdminReadModel>>(body);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(admins);
            Assert.Equal(expectedCount, admins.Count());
        }

        [Fact]
        public async Task RemoveUser()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.RemoveUser });

            var expectedId = 4;

            var response = await HttpClient.DeleteAsync($"api/admin/removeuser/id?id={expectedId}");

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
