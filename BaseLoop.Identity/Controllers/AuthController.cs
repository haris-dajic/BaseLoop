using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Identity.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaseLoop.Identity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public AuthController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("register")]
    public async Task<Guid> Register([FromBody] RegisterUserCommand command)
    {
        return await _dispatcher.DispatchAsync(command);
    }

    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginCommand loginCommand)
    {
        return await _dispatcher.DispatchAsync(loginCommand);
    }
}