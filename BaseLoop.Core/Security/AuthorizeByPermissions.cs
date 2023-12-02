using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BaseLoop.Core.Security;

public class AuthorizeByPermissions : AuthorizeAttribute, IAuthorizationFilter
{
    private const string AuthenticationScheme = "Bearer";
    private readonly string[] _permissions;

    public AuthorizeByPermissions(params string[] permissions)
    {
        _permissions = permissions;
        AuthenticationSchemes = AuthenticationScheme;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.Any(x => x is AllowAnonymousAttribute);
        if (allowAnonymous) return;

        var permissions =
            context.HttpContext.User.Claims.Where(c => c.Issuer == CoreConstants.PermissionsConstants.PermissionClaim)
                .Select(c => c.Value);

        var hasAtLeastOnePermisson = _permissions.Any(p => permissions.Contains(p));

        if (hasAtLeastOnePermisson)
            return;

        context.Result = new ForbidResult(AuthenticationScheme);
    }
}