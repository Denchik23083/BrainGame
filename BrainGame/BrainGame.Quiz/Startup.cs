using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BrainGame.Db;
using BrainGame.Logic.AuthService;
using BrainGame.Logic.QuizService;
using BrainGame.WebDb.AuthRepository;
using BrainGame.WebDb.QuizRepository;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Quiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<ICorrectsService, CorrectsService>();
            services.AddScoped<ICorrectsRepository, CorrectsRepository>();
            services.AddScoped<IPointService, PointService>();
            services.AddScoped<IPointRepository, PointRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrainGame.Quiz", Version = "v1" });
            });

            services.AddDbContext<BrainGameContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("BrainGame");

                options.UseSqlServer(connectionString);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("devCors", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrainGame.Quiz v1"));
                app.UseCors("devCors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            EnsureDbCreated(app);
        }

        private void EnsureDbCreated(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

            using var scope = scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<BrainGameContext>();

            context!.Database.EnsureCreated();
        }
    }
}