using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;
using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureServiceRegistration();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRouting();

var app = builder.Build();

app.UseStaticFiles(); 
app.UseHttpsRedirection();
app.UseRouting();
app.UseDefaultFiles();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.ConfigureLocalization();
app.ConfigureAndChechMigartion();
app.Run();