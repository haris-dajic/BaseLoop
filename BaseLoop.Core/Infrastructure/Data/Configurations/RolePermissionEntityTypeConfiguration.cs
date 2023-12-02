using BaseLoop.Core.Domain.Identity;
using BaseLoop.Core.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseLoop.Core.Infrastructure.Data.Configurations;

public class RolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(p => new {p.PermissionId, p.RoleId});

        var roles = Config.GetRoles();
        var permissions = Config.GetPermissions();

        var systemAdministratorRole = roles.FirstOrDefault(r => r.Name == RoleConstants.SystemAdministratorRole);
        var userManagementRole = roles.FirstOrDefault(r => r.Name == RoleConstants.UserManagementRole);
        var productManagementRole = roles.FirstOrDefault(r => r.Name == RoleConstants.ProductManagementRole);

        var permissionsForSystemAdministrator = permissions.Select(p => new RolePermission
            {PermissionId = p.Id, RoleId = systemAdministratorRole.Id}).ToList();
        var permissionsForUserManagement = permissions.Where(p => p.Domain == PermissionDomain.UserManagement)
            .Select(p => new RolePermission {PermissionId = p.Id, RoleId = userManagementRole.Id}).ToList();
        var permissionsForProductManagement = permissions.Where(p => p.Domain == PermissionDomain.ProductManagement)
            .Select(p => new RolePermission {PermissionId = p.Id, RoleId = productManagementRole.Id}).ToList();

        builder.HasData(permissionsForSystemAdministrator);
        builder.HasData(permissionsForUserManagement);
        builder.HasData(permissionsForProductManagement);
    }
}