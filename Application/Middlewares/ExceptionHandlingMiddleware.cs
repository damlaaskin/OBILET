using FluentValidation;
using OBILET.API.Application.Resources;
using System.Text.Json;

namespace OBILET.API.Application.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();

                var result = JsonSerializer.Serialize(new { errors });
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ValidationMessages.UnexpectedError);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ValidationMessages.UnexpectedError);
            }
        }
    }

}
