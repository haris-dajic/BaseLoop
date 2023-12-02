namespace BaseLoop.Core.Infrastructure.Authentication;

public interface IPermissionService
{
    Task<HashSet<string>> GetUserPermissionsByUserId(Guid userId);
}