using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig.QuizConfig
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quizzes>
    {
        public void Configure(EntityTypeBuilder<Quizzes> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).HasMaxLength(255);
            builder.Property(_ => _.Point).HasDefaultValue(0);

            builder.HasData(
                new Quizzes
                {
                    Id = 1,
                    Name = "Animals",
                    Point = 0
                },
                new Quizzes
                {
                    Id = 2,
                    Name = "Plants",
                    Point = 0
                },
                new Quizzes
                {
                    Id = 3,
                    Name = "Mushrooms",
                    Point = 0
                });
        }
    }
}