using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Email).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Password).IsRequired().HasMaxLength(255);
        }
    }
}