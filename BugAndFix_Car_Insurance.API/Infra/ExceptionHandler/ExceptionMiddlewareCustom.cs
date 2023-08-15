using System.Net;

namespace BugAndFix_Car_Insurance.API.Infra.ExceptionHandler;

public class ExceptionMiddlewareCustom
{

    private readonly RequestDelegate _next;
    public ExceptionMiddlewareCustom(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            //Message = "Internal Server Error from the custom middleware."
            Message = exception.Message
        }.ToString()); ;
    }
}