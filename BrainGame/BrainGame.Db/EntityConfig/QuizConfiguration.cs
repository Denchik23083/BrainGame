using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quizzes>
    {
        public void Configure(EntityTypeBuilder<Quizzes> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).HasMaxLength(255);
            builder.Property(_ => _.Point).HasDefaultValue(0);
        }
    }
}
