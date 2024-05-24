using System.Net;

namespace WebLibrary.Backend.Models.Exceptions;

public class UnauthorizedException(string message) : StatusCodeException(message, statusCode)
{
    private const HttpStatusCode statusCode = HttpStatusCode.Unauthorized;
}
