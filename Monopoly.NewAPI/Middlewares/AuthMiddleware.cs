using Monopoly.Service.Helpers;

namespace Monopoly.NewAPI.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (!TokenHelper.VerifyJwt(token))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return; // Ukončí zpracování tohoto požadavku
        }

        // Pokud je autentizovaný, pokračuje na další middleware
        await _next(context);
    }
}