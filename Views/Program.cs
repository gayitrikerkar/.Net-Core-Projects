var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles(); // to use static files like bootstrap
//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{Id?}"
);
app.Run();
