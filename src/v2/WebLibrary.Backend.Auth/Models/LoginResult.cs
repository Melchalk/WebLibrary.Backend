namespace WebLibrary.Backend.Auth.Models;

public class LoginResult
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
}
