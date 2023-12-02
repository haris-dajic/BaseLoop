using System.Security.Authentication;
using BaseLoop.Core.Domain.Identity;
using BaseLoop.Core.Extensions;
using BaseLoop.Core.Infrastructure.Authentication;
using BaseLoop.Core.Infrastructure.Commands;
using BaseLoop.Core.Infrastructure.Data.Repositories;
using BaseLoop.Identity.Domain.Commands;

namespace BaseLoop.Identity.Domain.Handlers;

public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username, cancellationToken);

        UserValidation(user, request.Password);

        var token = await _jwtProvider.GenerateAsync(user);

        return token;
    }

    private static void UserValidation(User? user, string password)
    {
        if (user is null) throw new AuthenticationException("Invalid username or password.");

        if (!PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            throw new AuthenticationException("Invalid username or password.");
    }
}