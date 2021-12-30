using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class PlantsQuestionsConfiguration : IEntityTypeConfiguration<PlantsQuestions>
    {
        public void Configure(EntityTypeBuilder<PlantsQuestions> builder)
        {
            builder.HasKey(_ => _.Id);

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
