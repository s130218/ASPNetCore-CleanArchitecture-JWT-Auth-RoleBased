using System.ComponentModel.DataAnnotations;

namespace IdentityCleanArch.Core.Domain.Security.DbEntity;

public class LoginModel
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get; set; }
    public int ExpiryMinutes { get; set; }
}
