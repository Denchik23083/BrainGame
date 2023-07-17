namespace BrainGame.Tests.Auth.AuthApiConfiguration
{
    public class AuthApiTestBase
    {
        protected readonly HttpClient HttpClient;

        public AuthApiTestBase()
        {
            var app = new AuthApiFactory();
            HttpClient = app.CreateDefaultClient();
        }
    }
}
