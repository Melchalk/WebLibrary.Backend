using Microsoft.AspNetCore.Http;

namespace WebLibrary.Backend.Auth.Helpers;

public static class HttpContextExtensions
{
    public static string GetUserPhone(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.Items["UserPhone"].ToString()!;
    }
}
