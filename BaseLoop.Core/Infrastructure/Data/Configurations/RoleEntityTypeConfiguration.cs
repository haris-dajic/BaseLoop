using BaseLoop.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseLoop.Core.Infrastructure.Data.Configurations;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasMany<Permission>().WithMany().UsingEntity<RolePermission>();

        // builder.HasMany<User>().WithMany();

        builder.HasData(Config.GetRoles());
    }
}