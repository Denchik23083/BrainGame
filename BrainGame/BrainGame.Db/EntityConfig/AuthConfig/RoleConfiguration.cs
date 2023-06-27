using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfig.AuthConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.RoleType).HasConversion<int>();

            builder.HasMany(_ => _.RolePermissions)
                .WithOne(_ => _.Role)
                .HasForeignKey(_ => _.RoleId);

            builder.ToTable("Roles").HasData(
                new Role 
                { 
                    Id = 1, 
                    RoleType = RoleType.God 
                },
                new Role 
                { 
                    Id = 2,
                    RoleType = RoleType.Admin
                },
                new Role
                {
                    Id = 3,
                    RoleType = RoleType.User
                });
        }
    }
}
