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
            builder.HasOne(_ => _.Correct)
                .WithMany()
                .HasForeignKey(_ => _.CorrectAnswerId);
            builder.HasOne(_ => _.Quizzes)
                .WithMany()
                .HasForeignKey(_ => _.QuizId);
        }
    }
}