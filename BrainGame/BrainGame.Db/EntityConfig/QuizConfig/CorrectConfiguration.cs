using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig.QuizConfig
{
    public class CorrectConfiguration : IEntityTypeConfiguration<Correct>
    {
        public void Configure(EntityTypeBuilder<Correct> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.CorrectAnswer).IsRequired().HasMaxLength(255);

            builder.HasOne(_ => _.Question)
                .WithOne(_ => _.Correct)
                .HasForeignKey<Correct>(_ => _.QuestionId);

            builder.HasData(
                new Correct
                {
                    Id = 1, 
                    CorrectAnswer = "Собака",
                    QuestionId = 1
                },
                new Correct
                {
                    Id = 2, 
                    CorrectAnswer = "Их нет",
                    QuestionId = 4
                },
                new Correct
                {
                    Id = 3, 
                    CorrectAnswer = "Пингвин",
                    QuestionId = 3
                },
                new Correct
                {
                    Id = 4, 
                    CorrectAnswer = "Арахис",
                    QuestionId = 5
                },
                new Correct
                {
                    Id = 5, 
                    CorrectAnswer = "Мухоморы",
                    QuestionId = 2
                },
                new Correct
                {
                    Id = 6, 
                    CorrectAnswer = "Боровик",
                    QuestionId = 6
                });
        }
    }
}