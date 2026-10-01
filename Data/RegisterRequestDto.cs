using System.ComponentModel.DataAnnotations;
namespace BlazorIdentityApiDemo.Data;

public class RegisterRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
public class LoginResponse
{
    public string TokenType { get; set; } = string.Empty;

    public string AccessToken { get; set; } = string.Empty;

    public int ExpiresIn { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
}
public class TokenStore
{
    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }
}