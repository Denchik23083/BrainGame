using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class BrainGameContext : DbContext
    {
        public BrainGameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<AnimalQuestions> AnimalQuestions { get; set; }

        public DbSet<PlantsQuestions> PlantsQuestions { get; set; }

        public DbSet<MushroomsQuestions> MushroomsQuestions { get; set; }

        public DbSet<Correct> Corrects { get; set; }

        public DbSet<Quizzes> Quizzes { get; set; }
    }
}