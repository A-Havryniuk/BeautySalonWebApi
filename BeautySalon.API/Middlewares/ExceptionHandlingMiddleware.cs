using System.Net;
using System.Text.Json;
using BeautySalon.Contracts.Exceptions;

namespace BeautySalon.API.Middlewares;


public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var jsonResponse = JsonSerializer.Serialize(new ApiException(exception.Message, context.Response.StatusCode));
        return context.Response.WriteAsync(jsonResponse);
    }
}