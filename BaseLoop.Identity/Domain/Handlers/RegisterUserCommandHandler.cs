using System.Security.Authentication;
using BaseLoop.Core.Domain.Identity;
using BaseLoop.Core.Extensions;
using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Core.Infrastructure.Data.Repositories;
using BaseLoop.Identity.Domain.Commands;
using Microsoft.Extensions.Logging;

namespace BaseLoop.Identity.Domain.Handlers;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly ILogger<RegisterUserCommandHandler> _logger;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(ILogger<RegisterUserCommandHandler> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await IsAlreadyExistingUserAsync(request.Username, request.Email, cancellationToken);

        var (passwordHash, passwordSalt) = PasswordHasher.HashPassword(request.Password);

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Username = request.Username,
            Email = request.Email,
            Birthday = request.Birthday,
            Address = request.Address,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.RegisterUserAsync(user, cancellationToken);

        return user.Id;
    }

    private async Task IsAlreadyExistingUserAsync(string username, string email, CancellationToken cancellationToken)
    {
        var userExist = await _userRepository.UserWithUsernameEmailExist(username, email, cancellationToken);

        if (userExist)
            throw new AuthenticationException();
    }
}