using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using Test.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);
var configuration =

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(HrManagerContext));

builder.Services.AddDbContext<HrManagerContext>(option =>
{
    option.UseSqlServer(new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build().GetConnectionString("DefaultConnection"));
});


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//.AddCookie(ob => {
//    ob.LoginPath = new PathString("/Login");
//});

var app = builder.Build();

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
