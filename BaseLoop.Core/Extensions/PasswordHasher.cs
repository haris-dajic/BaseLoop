namespace BaseLoop.Core.Extensions;

public static class PasswordHasher
{
    public static (string HashedPassword, string Salt) HashPassword(string plainPassword)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, salt);

        return (hashedPassword, salt);
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword, string salt)
    {
        var hashedEnteredPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, salt);
        return hashedEnteredPassword == hashedPassword;
    }
}