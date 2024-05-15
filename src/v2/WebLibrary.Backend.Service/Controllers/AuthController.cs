using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLibrary.Backend.Auth.Models;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Models.DTO.Requests.Librarian;
using WebLibrary.Backend.Models.DTO.Responses.Librarian;

namespace WebLibrary.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(
    [FromServices] IUserService userService,
    [FromServices] IAuthService authService)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<LoginResult> LoginUser(
        [FromBody] LoginRequest request,
        CancellationToken token)
    {
        return await authService.LoginUser(request, token);
    }

    [HttpPost("register")]
    public async Task<LoginResult> RegisterUser(
        [FromBody] CreateLibrarianRequest request,
        CancellationToken token)
    {
        var user = await userService.RegisterUser(request, token);

        return new LoginResult
        {
            AccessToken = authService.GenerateToken(user, TokenType.Access, out DateTime accessTokenLifetime),
            RefreshToken = authService.GenerateToken(user, TokenType.Refresh, out DateTime refreshTokenLifetime)
        };
    }

    [Authorize]
    [HttpGet("get/current")]
    public async Task<GetLibrarianResponse> GetCurrentUser(CancellationToken token)
    {
        return await userService.GetCurrentUser(token);
    }

    [Authorize]
    [HttpDelete("delete/current")]
    public async Task DeleteCurrentUser(CancellationToken token)
    {
        await userService.DeleteCurrentUser(token);
    }
}