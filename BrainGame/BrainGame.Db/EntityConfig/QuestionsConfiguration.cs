using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Question).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Answers).IsRequired();
            builder.HasOne(_ => _.Correct)
                .WithMany()
                .HasForeignKey(_ => _.CorrectAnswerId);
            builder.HasOne(_ => _.Quiz)
                .WithMany()
                .HasForeignKey(_ => _.QuizId);
        }
    }
}
