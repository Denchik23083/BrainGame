using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class BrainGameContext : DbContext
    {
        public BrainGameContext(DbContextOptions<BrainGameContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Questions> Questions { get; set; }

        public DbSet<Correct> Corrects { get; set; }

        public DbSet<Quizzes> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}