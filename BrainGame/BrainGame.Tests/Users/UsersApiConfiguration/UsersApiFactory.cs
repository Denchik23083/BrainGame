using BrainGame.Users;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BrainGame.Logic.UsersService.AdminService;
using BrainGame.Logic.UsersService.GodService;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.GodRepository;

namespace BrainGame.Tests.Users.UsersApiConfiguration
{
    public class UsersApiFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IUserRepository, UserRepository>();

                services.AddScoped<IAdminService, AdminService>();
                services.AddScoped<IAdminRepository, AdminRepository>();

                services.AddScoped<IGodService, GodService>();
                services.AddScoped<IGodRepository, GodRepository>();
            });

            return base.CreateHost(builder);
        }
    }
}
