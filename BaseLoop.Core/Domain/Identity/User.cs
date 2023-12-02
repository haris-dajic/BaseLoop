using System.ComponentModel.DataAnnotations;

namespace BaseLoop.Core.Domain.Identity;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Username { get; set; }

    [Required] [MinLength(8)] public string PasswordHash { get; set; }

    [Required] public string PasswordSalt { get; set; }

    public string Address { get; set; }

    [DataType(DataType.Date)] public DateTime Birthday { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
}