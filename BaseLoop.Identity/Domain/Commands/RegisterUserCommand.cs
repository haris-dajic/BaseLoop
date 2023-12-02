using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Identity.Domain.Handlers;
using FluentValidation;

namespace BaseLoop.Identity.Domain.Commands;

/// <summary>
///     See <see cref="RegisterUserCommandHandler.Handle" /> for command handler.
/// </summary>
public class RegisterUserCommand : ICommand<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public string Address { get; set; }
}

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.FirstName).NotNull().MinimumLength(2).MaximumLength(50);
        RuleFor(u => u.LastName).NotNull().MinimumLength(2).MaximumLength(50);
        RuleFor(u => u.Email).NotNull().EmailAddress();
        RuleFor(u => u.Username).NotNull().MinimumLength(4).MaximumLength(30);
        RuleFor(u => u.Password).NotNull().MinimumLength(8).MaximumLength(50);
        RuleFor(u => u.Birthday).NotNull();
    }
}