using BaseLoop.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseLoop.Core.Infrastructure.Data.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly CoreDbContext _context;

    public UserRepository(CoreDbContext coreDbContext)
    {
        _context = coreDbContext;
    }

    public async Task RegisterUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task<bool> UserWithUsernameEmailExist(string username, string email,
        CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking()
            .AnyAsync(u => u.Username == username || u.Email == email, cancellationToken);
    }
}