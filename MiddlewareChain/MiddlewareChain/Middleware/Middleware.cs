namespace MiddlewareChain.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
            {
                string fullname = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];
                await httpContext.Response.WriteAsync(fullname+"\n");
            }
            await httpContext.Response.WriteAsync("Extended Middleware Chain Start\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Extened Middleware Chain End\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
