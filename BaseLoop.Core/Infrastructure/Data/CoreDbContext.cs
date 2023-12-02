using BaseLoop.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseLoop.Core.Infrastructure.Data;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
        if (!Database.IsSqlServer())
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    // public DbSet<UserRole> UserRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreAssembly).Assembly); //Test this.
    }
}