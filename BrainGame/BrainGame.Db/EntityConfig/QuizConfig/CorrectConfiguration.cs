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

            builder.HasData(
                new Correct { Id = 1, CorrectAnswer = "Собака" },
                new Correct { Id = 2, CorrectAnswer = "Их нет" },
                new Correct { Id = 3, CorrectAnswer = "Пингвин" },
                new Correct { Id = 4, CorrectAnswer = "Арахис" },
                new Correct { Id = 5, CorrectAnswer = "Мухоморы" },
                new Correct { Id = 6, CorrectAnswer = "Боровик" });
        }
    }
}