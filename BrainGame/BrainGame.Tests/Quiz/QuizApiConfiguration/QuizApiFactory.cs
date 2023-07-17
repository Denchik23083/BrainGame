using BrainGame.Quiz;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.WebDb.UsersRepository.UserRepository;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BrainGame.Tests.Quiz.QuizApiConfiguration
{
    public class QuizApiFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

            });

            return base.CreateHost(builder);
        }
    }
}
