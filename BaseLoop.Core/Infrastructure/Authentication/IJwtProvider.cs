using BaseLoop.Core.Domain.Identity;

namespace BaseLoop.Core.Infrastructure.Authentication;

public interface IJwtProvider
{
    Task<string> GenerateAsync(User user);
}