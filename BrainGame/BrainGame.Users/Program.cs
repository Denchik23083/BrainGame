using BrainGame.Db;
using BrainGame.Users.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BrainGame.Logic.UsersService.UserService;
using BrainGame.Logic.UsersService.AdminService;
using BrainGame.Logic.UsersService.GodService;
using BrainGame.WebDb.UsersRepository.UserRepository;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.GodRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IGodService, GodService>();
builder.Services.AddScoped<IGodRepository, GodRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        var secretKey = builder.Configuration["SecretKey"];

        var secret = Encoding.UTF8.GetBytes(secretKey);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secret)
        };
    });

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("devCors");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

namespace BrainGame.Users
{
    public partial class Program { }
}
