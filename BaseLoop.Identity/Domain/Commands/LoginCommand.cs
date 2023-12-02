using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Identity.Domain.Handlers;
using FluentValidation;

namespace BaseLoop.Identity.Domain.Commands;

/// <summary>
///     See <see cref="LoginCommandHandler.Handle" /> for command handler.
/// </summary>
public class LoginCommand : ICommand<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.Username).NotNull().MinimumLength(4).MaximumLength(30);
        RuleFor(u => u.Password).NotNull().MinimumLength(8).MaximumLength(50);
    }
}