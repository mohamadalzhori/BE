
using CodeFirst.Common.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using System.Net;

namespace CodeFirst.Common.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (StudentNotFoundException ex)
            {
                _logger.LogInformation("======================================================================================");
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("======================================================================================");

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";

                var errorMessage = JsonConvert.SerializeObject(new { error = ex.Message });
                await context.Response.WriteAsync(errorMessage);
            }
            catch (ClassNotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";

                var errorMessage = JsonConvert.SerializeObject(new { error = ex.Message });
                await context.Response.WriteAsync(errorMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                // return error message
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;


                // If in MVC, redirect to an error page
                //context.Response.Redirect("/Home/Error");
            }
        }
    }
}
