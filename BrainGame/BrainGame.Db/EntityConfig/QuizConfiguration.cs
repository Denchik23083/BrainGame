using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Question).IsRequired().HasMaxLength(255);
        }
    }
}
