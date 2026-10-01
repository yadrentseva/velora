using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace velora.Handlers
{
    public class CentralExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";
            var problem = new ProblemDetails()
            {
                Status = httpContext.Response.StatusCode,
                Title = "Internal Server Error",
                Detail = exception.Message,
                Instance = httpContext.Request.Path,
                Type = "ServerError"
            };
            problem.Extensions["traceId"] = httpContext.TraceIdentifier;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }
    }
}