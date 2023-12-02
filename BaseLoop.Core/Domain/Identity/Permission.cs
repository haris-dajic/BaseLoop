namespace BaseLoop.Core.Domain.Identity;

public class Permission
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PermissionDomain Domain { get; set; }

    public string Description { get; set; }
    // public virtual ICollection<Role> Roles { get; set; }
}