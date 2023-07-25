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
        public async void GetAdmins()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.AdminToUser });

            var expectedCount = 1;

            var response = await HttpClient.GetAsync("api/admin");

            var body = await response.Content.ReadAsStringAsync();

            var admins = JsonConvert.DeserializeObject<IEnumerable<AdminReadModel>>(body);

            Assert.NotNull(admins);
            Assert.Equal(expectedCount, admins.Count());
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async void RemoveUser()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.RemoveUser });

            var expectedId = 5;

            var response = await HttpClient.DeleteAsync($"api/admin/removeuser/id?id={expectedId}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
