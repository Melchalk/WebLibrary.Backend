using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebLibrary.Backend.Auth.Helpers;
using WebLibrary.Backend.Auth.Models;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Models.Db;

namespace WebLibrary.Backend.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly TokenSettings _tokenSettings;

    public AuthService(
        IUserService userService,
        IOptions<TokenSettings> tokenSettings)
    {
        _userService = userService;
        _tokenSettings = tokenSettings.Value;
    }

    public async Task<LoginResult> LoginUser(LoginRequest request, CancellationToken token)
    {
        var user = await _userService.GetUserByPhone(request.Phone, token);

        PasswordHelper.VerifyPasswordHash(
            request.Phone,
            request.Password,
            user.Salt,
            user.Password);

        return new LoginResult
        {
            AccessToken = GenerateToken(user, TokenType.Access, out DateTime accessTokenLifetime),
            RefreshToken = GenerateToken(user, TokenType.Refresh, out DateTime refreshTokenLifetime),
        };
    }

    public string GenerateToken(DbLibrarian user, TokenType tokenType, out DateTime tokenLifetime)
    {
        List<Claim> claims =
        [
            new Claim(ClaimTypes.MobilePhone, user.Phone),
        ];

        tokenLifetime = DateTime.UtcNow.Add(
            tokenType == TokenType.Access
                ? TimeSpan.FromMinutes(_tokenSettings.AccessTokenLifetimeInMinutes)
                : TimeSpan.FromMinutes(_tokenSettings.RefreshTokenLifetimeInMinutes));

        var jwt = new JwtSecurityToken(
            issuer: _tokenSettings.TokenIssuer,
            audience: _tokenSettings.TokenAudience,
            claims: claims,
            expires: tokenLifetime,
            signingCredentials: new SigningCredentials(
                SigningSymmetricKey.GetKey(),
                SigningSymmetricKey.SigningAlgorithm));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
