var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
var app = builder.Build();

app.UseRouting();
app.UseSession();
app.UseStaticFiles();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Start}/{id?}"
);

app.Run();
