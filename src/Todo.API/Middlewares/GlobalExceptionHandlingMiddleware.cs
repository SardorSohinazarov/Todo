using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Todo.Domain.Exceptions;

namespace Todo.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
        HttpContext httpContext,
        [FromServices] ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (TaskNotFoundException notFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

                var serializedObject = JsonSerializer.Serialize(new
                {
                    notFoundException.Message
                });

                logger.LogError(notFoundException, notFoundException.Message);

                await HandleExceptionAsync(httpContext, serializedObject);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);

                await HandleExceptionAsync(httpContext, exception.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(message);
        }
    }
}
