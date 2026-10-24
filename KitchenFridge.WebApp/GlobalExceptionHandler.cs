using KitchenFridge.Services.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KitchenFridge.WebApp
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler (ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "An unhandled exception occurred during request {TraceId}: {Message}",
                httpContext.TraceIdentifier,
                exception.Message);

            var statusCode = HttpStatusCode.InternalServerError;
            var title = "occured an unexpected error.";
            var detail = "Sorry, an error occurred. Please try again later or contact customer support.";

            if(exception is ValidationException badRequestException)
            {
                statusCode = HttpStatusCode.BadRequest;
                title = "validation error";
                detail = badRequestException.Message;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails
            {
                Status = (int)statusCode,
                Title = title,
                Detail = detail,
                Instance = httpContext.Request.Path,
                Extensions =
                {
                    { "traceId" , httpContext.TraceIdentifier }
                }
            };
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
