var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//require for conventional and attribute routing
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//context is for handling http request
//app.run cannot be used to run multiple middleware because there is no next delegate,for runnin multiple middlewares use use
//for single middleware use run,for multiple middleware use "use"
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Welcome to first middleware \n");
//    await next(context);//transferring request to next middleware
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Welcome to second middleware \n");
//    await next(context);//transferring request to next middleware
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Welcome to third middleware \n");
//    await next(context);//transferring request to next middleware,make sure there is a next middleware wriiten
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Welcome to ASP.Net 8 Basics");
//});

//app.MapDefaultControllerRoute(); //this method will call only the home controller and its index method

//app.MapControllerRoute(
//name:"default",
//pattern:"{controller=Home}/{action=About}/{Id?}"
//);//conventiinl routing by setting routes in which routes are determined based on the conventions set in the routes.conventional routes=url+conventions


app.MapControllers();//for attribute routing
app.Run();
