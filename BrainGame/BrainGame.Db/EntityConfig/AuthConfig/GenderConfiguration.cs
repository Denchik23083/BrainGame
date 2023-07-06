using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig.AuthConfig
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Type).HasConversion<int>();

            builder.ToTable("Genders").HasData(
                new Gender { Id = 1, Type = GenderType.Male },
                new Gender { Id = 2, Type = GenderType.Female });
        }
    }
}
