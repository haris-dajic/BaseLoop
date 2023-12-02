using BaseLoop.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BaseLoop.Core.Infrastructure.Authentication;

public class PermissionService : IPermissionService
{
    private readonly CoreDbContext _context;

    public PermissionService(CoreDbContext context)
    {
        _context = context;
    }

    public async Task<HashSet<string>> GetUserPermissionsByUserId(Guid userId)
    {
        try
        {
            var user = await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Permissions)
                .Where(u => u.Id == userId)
                .ToListAsync();

            return user.SelectMany(u => u.Roles).SelectMany(r => r.Permissions).Select(p => p.Name).ToHashSet();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}