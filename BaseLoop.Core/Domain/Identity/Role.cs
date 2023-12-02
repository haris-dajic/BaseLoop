namespace BaseLoop.Core.Domain.Identity;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<User> Users { get; set; }

    // public virtual ICollection<RolePermission> AssignedPermissions { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
}