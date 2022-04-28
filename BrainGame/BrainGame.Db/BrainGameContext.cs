using BrainGame.Db.Entities.Auth;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class BrainGameContext : DbContext
    {
        public BrainGameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quizzes>().HasData(
                new Quizzes
                {
                    Id = 1, 
                    Name = "Animals", 
                    Point = 0
                },
                new Quizzes
                {
                    Id = 2,
                    Name = "Animals",
                    Point = 0
                },
                new Quizzes
                {
                    Id = 3, 
                    Name = "Mushrooms",
                    Point = 0
                });

            modelBuilder.Entity<Correct>().HasData(
                new Correct { Id = 1, CorrectAnswer = "Собака" },
                new Correct { Id = 2, CorrectAnswer = "Их нет" },
                new Correct { Id = 3, CorrectAnswer = "Пингвин" },
                new Correct { Id = 4, CorrectAnswer = "Арахис" },
                new Correct { Id = 5, CorrectAnswer = "Мухоморы" },
                new Correct { Id = 6, CorrectAnswer = "Боровик" });

            modelBuilder.Entity<Questions>().HasData(
                new Questions
                {
                    Id = 1,
                    Number = 1,
                    Question = "Кто гавкает?",
                    Answers = "Собака,Кошка,Хомяк",
                    CorrectAnswerId = 1,
                    QuizId = 1
                },
                new Questions
                {
                    Id = 2,
                    Number = 1,
                    Question = "Какие грибы ядовитые?",
                    Answers = "Лисички,Опята,Мухоморы",
                    CorrectAnswerId = 5,
                    QuizId = 3
                },
                new Questions
                {
                    Id = 3,
                    Number = 2,
                    Question = "Какая птица не умеет летать?",
                    Answers = "Орел,Пингвин,Ворон",
                    CorrectAnswerId = 3,
                    QuizId = 1
                },
                new Questions
                {
                    Id = 4,
                    Number = 1,
                    Question = "Какого цвета листья у деревьев зимой?",
                    Answers = "Зеленые,Желтые,Их нет",
                    CorrectAnswerId = 2,
                    QuizId = 2
                },
                new Questions
                {
                    Id = 5,
                    Number = 2,
                    Question = "Как называется земляной орех?",
                    Answers = "Арахис,Фисташки,Грецкие",
                    CorrectAnswerId = 4,
                    QuizId = 2
                },
                new Questions
                {
                    Id = 6,
                    Number = 2,
                    Question = "Как еще называют Белый гриб?",
                    Answers = "Волнушка,Боровик,Лисичка",
                    CorrectAnswerId = 6,
                    QuizId = 3
                });

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Questions> Questions { get; set; }

        public DbSet<Correct> Corrects { get; set; }

        public DbSet<Quizzes> Quizzes { get; set; }
    }
}