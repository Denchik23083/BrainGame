using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class TestsBrainGameContext : DbContext
    {
        public TestsBrainGameContext() { }

        public TestsBrainGameContext(DbContextOptions<TestsBrainGameContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Questions> Questions { get; set; }

        public DbSet<Correct> Corrects { get; set; }

        public DbSet<Quizzes> Quizzes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestsBrainGame;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
