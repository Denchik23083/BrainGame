using BrainGame.Logic.QuizService.CorrectService;
using BrainGame.Logic.QuizService.QuestionService;
using BrainGame.Logic.QuizService.QuizService;
using BrainGame.Logic.QuizService.StatisticsService;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.Quiz;
using BrainGame.WebDb.QuizRepository.CorrectRepository;
using BrainGame.WebDb.QuizRepository.QuestionRepository;
using BrainGame.WebDb.QuizRepository.QuizRepository;
using BrainGame.WebDb.QuizRepository.StatisticsRepository;
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
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IUserRepository, UserRepository>();

                services.AddScoped<IStatisticsService, StatisticsService>();
                services.AddScoped<IStatisticsRepository, StatisticsRepository>();
                
                services.AddScoped<IQuizService, QuizService>();
                services.AddScoped<IQuizRepository, QuizRepository>();
                
                services.AddScoped<IQuestionService, QuestionService>();
                services.AddScoped<IQuestionRepository, QuestionRepository>();
                
                services.AddScoped<ICorrectService, CorrectService>();
                services.AddScoped<ICorrectRepository, CorrectRepository>();
            });

            return base.CreateHost(builder);
        }
    }
}
