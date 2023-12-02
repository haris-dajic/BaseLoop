using BaseLoop.Core.Domain.Identity;

namespace BaseLoop.Core.Infrastructure.Data.Repositories;

public interface IUserRepository
{
    Task RegisterUserAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> UserWithUsernameEmailExist(string username, string email, CancellationToken cancellationToken = default);
}