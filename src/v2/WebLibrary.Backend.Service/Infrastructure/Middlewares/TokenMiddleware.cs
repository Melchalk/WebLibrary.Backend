using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebLibrary.Backend.Auth.Models;
using WebLibrary.Backend.Auth.Services.Interfaces;
using WebLibrary.Backend.Models.Exceptions;

namespace WebLibrary.Infrastructure.Middlewares;

public class TokenMiddleware
{
    private const string UserPhone = "UserPhone";

    private readonly RequestDelegate _next;

    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IAuthService authService)
    {
        if (string.Equals(context.Request.Method, "OPTIONS", StringComparison.OrdinalIgnoreCase) ||
            context.Request.Path.StartsWithSegments(new PathString("/swagger")))
        {
            await _next(context);
            return;
        }

        var endpoint = context.GetEndpoint() ?? throw new Exception("Endpoint was null.");

        if (!endpoint.Metadata.OfType<AuthorizeAttribute>().Any())
        {
            await _next(context);

            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last()
            ?? throw new UnauthorizedException("Token validation was failed.");

        var claims = authService.ValidateToken(token);

        var phone = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value;
        var tokenType = claims.Claims.FirstOrDefault(x => x.Type == "TokenType")?.Value;

        if (string.IsNullOrEmpty(phone) ||
            string.IsNullOrEmpty(tokenType) ||
            tokenType != TokenType.Access.ToString())
        {
            throw new UnauthorizedException("Token validation was failed.");
        }

        context.Items[UserPhone] = phone;

        await _next(context);
    }
}
