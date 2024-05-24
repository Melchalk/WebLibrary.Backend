namespace WebLibrary.Backend.Auth.Models;

public class LoginRequest
{
    public required string Phone { get; set; }
    public required string Password { get; set; }
}
