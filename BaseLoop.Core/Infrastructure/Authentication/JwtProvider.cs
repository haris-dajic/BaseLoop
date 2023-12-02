using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaseLoop.Core.Domain.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BaseLoop.Core.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _configuration;
    private readonly IPermissionService _permissionService;

    public JwtProvider(IConfiguration configuration, IPermissionService permissionService)
    {
        _configuration = configuration;
        _permissionService = permissionService;
    }

    public async Task<string> GenerateAsync(User user)
    {
        var claims = await GetUserClaims(user);

        var signInCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:SecurityKey"])),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Auth:Issuer"], _configuration["Auth:Audience"], claims, null,
            DateTime.UtcNow.AddHours(2),
            signInCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<List<Claim>> GetUserClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.Name, user.FirstName),
            new(ClaimTypes.Surname, user.LastName)
        };

        var permissions = await _permissionService.GetUserPermissionsByUserId(user.Id);

        foreach (var permission in permissions)
            claims.Add(new Claim(CoreConstants.PermissionsConstants.PermissionClaim, permission));

        return claims;
    }
}