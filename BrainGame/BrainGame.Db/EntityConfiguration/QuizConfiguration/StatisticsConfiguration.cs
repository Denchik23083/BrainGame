using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfiguration.QuizConfiguration
{
    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Point).HasDefaultValue(0);

            builder.HasOne(_ => _.Quizzes)
                .WithMany()
                .HasForeignKey(_ => _.QuizId);

            builder.HasOne(_ => _.User)
                .WithMany()
                .HasForeignKey(_ => _.UserId);
        }
    }
}
