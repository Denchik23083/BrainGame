using BrainGame.Db.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainGame.Db.EntityConfiguration.AuthConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Email).IsRequired().HasMaxLength(255);
            builder.Property(_ => _.Password).IsRequired().HasMaxLength(255);

            builder.HasOne(_ => _.Gender)
                .WithMany(_ => _.Users)
                .HasForeignKey(_ => _.GenderId);

            builder.HasOne(_ => _.Role)
                .WithMany()
                .HasForeignKey(_ => _.RoleId);

            builder.ToTable("Users").HasData(
                new User
                {
                    Id = 1,
                    Name = "God",
                    Email = "god@gmail.com",
                    Password = "0000",
                    GenderId = 1,
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Ted",
                    Email = "admin@gmail.com",
                    Password = "0000",
                    GenderId = 1,
                    RoleId = 2
                },
                new User
                {
                    Id = 3,
                    Name = "Anna",
                    Email = "user@gmail.com",
                    Password = "0000",
                    GenderId = 2,
                    RoleId = 3
                });
        }
    }
}