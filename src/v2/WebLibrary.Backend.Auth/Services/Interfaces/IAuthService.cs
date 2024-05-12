using WebLibrary.Backend.Auth.Models;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Auth.Services.Interfaces;

public interface IAuthService
{
    Task<LoginResult> LoginUser(LoginRequest request, CancellationToken token);

    string GenerateToken(DbLibrarian user, TokenType tokenType, out DateTime tokenLifetime);
}
