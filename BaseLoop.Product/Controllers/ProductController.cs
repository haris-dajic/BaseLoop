using BaseLoop.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BaseLoop.Product.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = $"{RoleConstants.SystemAdministratorRole},{RoleConstants.UserManagementRole}")]
    public IActionResult GetProducts()
    {
        return Ok("Uspjesno usao u 'GetProducts'");
    }

    [HttpPost("add")]
    public async Task AddProduct([FromBody] string product)
    {
        await Task.Delay(1);
    }

    [AllowAnonymous]
    [HttpGet("test")]
    public IActionResult Test()
    {
        _logger.LogInformation("Uspjesno usao u test kontoler");
        return Ok("Usao u test kontroller");
    }
}