using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BrainGame.Core.Utilities;

namespace BrainGame.Db.EntityConfig.AuthConfig
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.PermissionType).HasConversion<int>();

            builder.HasOne(_ => _.Role)
                .WithMany(_ => _.RolePermissions)
                .HasForeignKey(_ => _.RoleId);

            builder.ToTable("RolePermissions").HasData(
                new RolePermission
                {
                    Id = 1,
                    RoleId = 1,
                    PermissionType = PermissionType.GetQuiz
                },
                new RolePermission
                {
                    Id = 2,
                    RoleId = 1,
                    PermissionType = PermissionType.EditQuiz
                },
                new RolePermission
                {
                    Id = 3,
                    RoleId = 1,
                    PermissionType = PermissionType.RemoveUser
                },
                new RolePermission
                {
                    Id = 4,
                    RoleId = 1,
                    PermissionType = PermissionType.UserToAdmin
                },
                new RolePermission
                {
                    Id = 5,
                    RoleId = 1,
                    PermissionType = PermissionType.AdminToUser
                },
                new RolePermission
                {
                    Id = 6,
                    RoleId = 2,
                    PermissionType = PermissionType.GetQuiz
                },
                new RolePermission
                {
                    Id = 7,
                    RoleId = 2,
                    PermissionType = PermissionType.EditQuiz
                },
                new RolePermission
                {
                    Id = 8,
                    RoleId = 2,
                    PermissionType = PermissionType.RemoveUser
                },
                new RolePermission
                {
                    Id = 9,
                    RoleId = 3,
                    PermissionType = PermissionType.GetQuiz
                });
        }
    }
}
