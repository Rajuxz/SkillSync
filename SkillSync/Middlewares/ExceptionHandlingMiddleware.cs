using System.Linq.Expressions;
using System.Net;

namespace SkillSync.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                //Unique error id for each exception generated
                var errorId = Guid.NewGuid().ToString();
                //log the exception
                _logger.LogError(ex, $"{errorId}:{ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var error = new
                {
                    Id = errorId,
                    Message = "An unexpected error occurred. Please try again later.",
                };
                await context.Response.WriteAsJsonAsync(error);

            }
        }

    }
}
