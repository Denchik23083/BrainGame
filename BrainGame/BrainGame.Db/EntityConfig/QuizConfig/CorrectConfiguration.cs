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
        }
    }
}