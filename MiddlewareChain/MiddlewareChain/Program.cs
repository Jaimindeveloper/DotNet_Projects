using MiddlewareChain.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("First Middleware \n");
//    await next(context);
//});

// app.UseMiddleware();
app.UseLoginMiddleware();

//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("Third Middleware \n");
//});

app.Run();
