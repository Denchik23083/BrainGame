using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfiguration.AuthConfiguration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Value);

            builder.HasOne(_ => _.User)
                .WithOne(_ => _.RefreshToken)
                .HasForeignKey<RefreshToken>(_ => _.UserId);
        }
    }
}
