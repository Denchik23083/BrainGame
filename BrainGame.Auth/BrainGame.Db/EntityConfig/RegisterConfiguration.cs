using System;
using System.Collections.Generic;
using System.Text;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Login).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Password).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.ConfirmPassword).IsRequired().HasMaxLength(255);
        }
    }
}
