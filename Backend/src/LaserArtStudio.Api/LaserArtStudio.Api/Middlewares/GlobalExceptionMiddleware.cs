using LaserArtStudio.Application.Common.Exceptions;
using System.Text.Json;

namespace LaserArtStudio.Api.Middlewares
{
    public sealed class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                RequestValidationException validationException =>
                    CreateValidationResponse(context, validationException),

                NotFoundException notFoundException =>
                    CreateNotFoundResponse(context, notFoundException),

                ConflictException conflictException =>
                    CreateConflictResponse(context, conflictException),

                _ => CreateInternalServerError(context)
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }

        private static object CreateValidationResponse(
            HttpContext context,
            RequestValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            return new
            {
                Success = false,
                Message = exception.Message,
                Errors = exception.Errors
            };
        }

        private static object CreateNotFoundResponse(
            HttpContext context,
            NotFoundException exception)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            return new
            {
                Success = false,
                Message = exception.Message
            };
        }

        private static object CreateConflictResponse(
            HttpContext context,
            ConflictException exception)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;

            return new
            {
                Success = false,
                Message = exception.Message
            };
        }

        private static object CreateInternalServerError(
            HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return new
            {
                Success = false,
                Message = "An unexpected error occurred."
            };
        }
    }
}
