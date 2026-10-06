using System.ComponentModel.DataAnnotations;
using System.Text.Json;

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

public sealed class BrowserApiResponse
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public bool IsSuccess { get; set; }

    public int Status { get; set; }

    public string Body { get; set; } = string.Empty;

    public T? ReadJson<T>()
    {
        return JsonSerializer.Deserialize<T>(Body, JsonOptions);
    }
}