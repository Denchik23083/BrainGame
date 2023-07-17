using BrainGame.Auth;
using BrainGame.Logic.AuthService;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.WebDb.AuthRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BrainGame.Tests.Auth.AuthApiConfiguration
{
    public class AuthApiFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IAuthRepository, AuthRepository>();

                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IUserRepository, UserRepository>();
            });

            return base.CreateHost(builder);
        }
    }
}
