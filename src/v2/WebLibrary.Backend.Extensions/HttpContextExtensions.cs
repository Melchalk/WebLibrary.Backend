using Microsoft.AspNetCore.Http;

namespace WebLibrary.Backend.Extensions;

public static class HttpContextExtensions
{
    public static string GetUserPhone(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext.Items["UserPhone"].ToString()!;
    }
}
