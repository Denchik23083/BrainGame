using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig.QuizConfig
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Number).IsRequired();
            builder.Property(_ => _.Question).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Answers).IsRequired();
            
            builder.HasOne(_ => _.Quizzes)
                .WithMany()
                .HasForeignKey(_ => _.QuizId);

            builder.HasData(
                new Questions
                {
                    Id = 1,
                    Number = 1,
                    Question = "Кто гавкает?",
                    Answers = "Собака,Кошка,Хомяк",
                    QuizId = 1
                },
                new Questions
                {
                    Id = 2,
                    Number = 1,
                    Question = "Какие грибы ядовитые?",
                    Answers = "Лисички,Опята,Мухоморы",
                    QuizId = 3
                },
                new Questions
                {
                    Id = 3,
                    Number = 2,
                    Question = "Какая птица не умеет летать?",
                    Answers = "Орел,Пингвин,Ворон",
                    QuizId = 1
                },
                new Questions
                {
                    Id = 4,
                    Number = 1,
                    Question = "Какого цвета листья у деревьев зимой?",
                    Answers = "Зеленые,Желтые,Их нет",
                    QuizId = 2
                },
                new Questions
                {
                    Id = 5,
                    Number = 2,
                    Question = "Как называется земляной орех?",
                    Answers = "Арахис,Фисташки,Грецкие",
                    QuizId = 2
                },
                new Questions
                {
                    Id = 6,
                    Number = 2,
                    Question = "Как еще называют Белый гриб?",
                    Answers = "Волнушка,Боровик,Лисичка",
                    QuizId = 3
                });
        }
    }
}