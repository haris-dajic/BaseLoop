using BaseLoop.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseLoop.Core.Infrastructure.Data.Configurations;

public class PermissionEntityTypeCOnfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasData(Config.GetPermissions());
    }
}