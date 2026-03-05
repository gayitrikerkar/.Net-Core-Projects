using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSession();//to use sessions
builder.Services.AddSession(
    options=>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(1);
    });//to set timespan for sessions
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//for directly using session in views 
var app = builder.Build();
app.UseSession();//to use session
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
