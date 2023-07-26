using BrainGame.Core.Utilities;
using BrainGame.Tests.Users.UsersApiConfiguration;
using BrainGame.Users.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace BrainGame.Tests.Users.UsersTests
{
    public class UserTests : UsersApiTestBase
    {
        [Fact]
        public async Task GetUsers()
        {
            AddTokenWithPermissions(new List<PermissionType> 
            { PermissionType.GetQuiz });

            var expectedCount = 1;

            var response = await HttpClient.GetAsync("api/user");

            var body = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<IEnumerable<UserReadModel>>(body);
                        
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(users);
            Assert.Equal(expectedCount, users.Count());
        }

        [Fact]
        public async Task EditUser()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.GetQuiz });

            var updateUser = new UserWriteModel
            {
                Name = "God",
                Email = "god@gmail.com"
            };

            var content = JsonContent.Create(updateUser);

            var response = await HttpClient.PutAsync("api/user", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task EditPassword()
        {
            AddTokenWithPermissions(new List<PermissionType>
            { PermissionType.GetQuiz });

            var updatePassword = new PasswordWriteModel
            {
                OldPassword = "0000",
                NewPassword = "0000",
                ConfirmPassword = "0000",
            };

            var content = JsonContent.Create(updatePassword);

            var response = await HttpClient.PutAsync("api/user/password", content);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}