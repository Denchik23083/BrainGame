using BrainGame.Db;
using BrainGame.Logic.AuthService;
using BrainGame.Logic.QuizService;
using BrainGame.Logic.StatisticsService;
using BrainGame.Logic.UserService;
using BrainGame.WebDb.AuthRepository;
using BrainGame.WebDb.QuizRepository;
using BrainGame.WebDb.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<ICorrectsService, CorrectsService>();
builder.Services.AddScoped<ICorrectsRepository, CorrectsRepository>();
builder.Services.AddScoped<IPointService, PointService>();
builder.Services.AddScoped<IPointRepository, PointRepository>();

//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddDbContext<BrainGameContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BrainGame");

    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("devCors", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetService<BrainGameContext>();

context!.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("devCors");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }