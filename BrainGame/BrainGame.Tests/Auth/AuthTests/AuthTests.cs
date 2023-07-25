using BrainGame.Auth.Models;
using BrainGame.Tests.Auth.AuthApiConfiguration;
using System.Net.Http.Json;
using System.Net;
using Xunit;
using Newtonsoft.Json;
using BrainGame.Core.Utilities;
using BrainGame.Users.Models;

namespace BrainGame.Tests.Auth.AuthTests
{
    public class AuthTests : AuthApiTestBase
    {
        [Fact]
        public async Task Register()
        {
            var register = new RegisterModel
            {
                Name = "Foo",
                GenderId = 1,
                Email = "foo@gmail.com",
                Password = "0000",
                ConfirmPassword = "0000"
            };

            var content = JsonContent.Create(register);

            var response = await HttpClient.PostAsync("api/auth/register", content);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Login()
        {
            var login = new LoginModel
            {
                Email = "god@gmail.com",
                Password = "0000"
            };

            var content = JsonContent.Create(login);

            var response = await HttpClient.PostAsync("api/auth/login", content);

            var body = await response.Content.ReadAsStringAsync();

            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(body);

            Assert.NotNull(tokenModel);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Refresh()
        {
            var refreshToken = new RefreshTokenModel
            {
                Value = new Guid("7807e38d-3402-40d7-8eb5-aa697d347a85")
            };

            var content = JsonContent.Create(refreshToken);

            var response = await HttpClient.PostAsync("api/auth/login/refresh", content);

            var body = await response.Content.ReadAsStringAsync();

            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(body);

            Assert.NotNull(tokenModel);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async void GetGenders()
        {
            var expectedCount = 2;

            var response = await HttpClient.GetAsync("api/auth/register/gender");

            var body = await response.Content.ReadAsStringAsync();

            var genders = JsonConvert.DeserializeObject<IEnumerable<GenderModel>>(body);

            Assert.NotNull(genders);
            Assert.Equal(expectedCount, genders.Count());
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}