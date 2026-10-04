using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace velora.Handlers
{
    public class CentralExceptionHandler(ILogger<CentralExceptionHandler> _logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";
            var problem = new ProblemDetails()
            {
                Status = httpContext.Response.StatusCode,
                Title = "Internal Server Error",
                Detail = "An error occurred while processing the request",
                Instance = httpContext.Request.Path,
                Type = null
            };
            problem.Extensions["traceId"] = httpContext.TraceIdentifier;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            _logger.LogError(exception, "Unhandled exception");

            return true;
        }
    }
}