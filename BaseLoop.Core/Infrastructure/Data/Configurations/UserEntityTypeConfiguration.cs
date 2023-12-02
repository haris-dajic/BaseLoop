using BaseLoop.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseLoop.Core.Infrastructure.Data.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasData(new User
        {
            Id = new Guid("0F530343-18F4-4D9D-BC0B-6375A7FE905C"),
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            Username = "admin",
            PasswordSalt = "$2b$10$MSaUX8lTLYDVGV03kS3jF.",
            PasswordHash = "$2b$10$MSaUX8lTLYDVGV03kS3jF.ztL1oL2a4fJlyMBfYGO5vPJ5hd7lXdi",
            Address = "Aleja Bosne Srebrene 77",
            Birthday = new DateTime(1995, 11, 28)
        });
    }
}