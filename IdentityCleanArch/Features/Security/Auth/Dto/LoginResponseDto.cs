namespace IdentityCleanArch.Features.Security.Auth.Dto;

public class LoginResponseDto
{
    public string Token { get; set; }
    public int ExpiryMinutes { get; set; }
}
