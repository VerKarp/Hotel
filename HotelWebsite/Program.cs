using HotelWebsite.Models;
using HotelWebsite.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddMvc();
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

builder.Services.AddSingleton<Email>(e => new(builder.Configuration));
builder.Services.AddSingleton<EmailService>(s => new(s.GetRequiredService<Email>()));

builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
