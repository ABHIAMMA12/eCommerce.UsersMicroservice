using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace UsersMicroservice.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.GetType().ToString()} : {ex.Message}");
                if (ex.InnerException is not null)
                {
                    Log.Error($"{ex.InnerException.GetType().ToString()}: {ex.InnerException.Message}");
                }
                //set the response status code
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { message = ex.Message, type = ex.GetType().ToString() });
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
