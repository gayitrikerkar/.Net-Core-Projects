var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("Home/", () => "Hello World!");//map methods works for all methods,get,post,delete,put

//for testing use postman
app.MapGet("/", () => "hello world! - get");
app.MapPost("/", () => "Hello World! - Post");
app.MapPut("/", () => "Hello World! - Put");
app.MapDelete("/", () => "Hello World! - Delete");

//for multiple lines of codes for each method

//app.UseRouting();//activating routing
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/Home", async (context) =>
//    {
//        await context.Response.WriteAsync("This is home page -Get");
//    });
//    endpoints.MapPost("/Home", async (context) =>
//    {
//        await context.Response.WriteAsync("This is home page -Post");
//    });
//    endpoints.MapPut("/Home", async (context) =>
//    {
//        await context.Response.WriteAsync("This is home page -Put");
//    });
//    endpoints.MapDelete("/Home", async (context) =>
//    {
//        await context.Response.WriteAsync("This is home page -Delete");

//    });

//});


//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("page not found");
//});
app.Run();