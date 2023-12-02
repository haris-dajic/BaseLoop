using BaseLoop.Core.Security;
using Microsoft.AspNetCore.Mvc;

namespace BaseLoop.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // [HttpPost("add")]
    // public Task AddUser([FromBody] )

    [AuthorizeByPermissions(PermissionConstants.UserManagement.AddUser)]
    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Prosao");
    }
}