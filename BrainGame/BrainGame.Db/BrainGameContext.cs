using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class BrainGameContext : DbContext
    {
        public BrainGameContext(DbContextOptions<BrainGameContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Gender> Genders { get; set; } = null!;

        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public DbSet<Questions> Questions { get; set; } = null!;

        public DbSet<Correct> Corrects { get; set; } = null!;

        public DbSet<Quizzes> Quizzes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}