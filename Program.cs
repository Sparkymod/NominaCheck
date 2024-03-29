using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NominaCheck.Data.Services;
using NominaCheck.Data.Extensions;
using Serilog;
using NominaCheck;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAllServicesAvailable();
builder.Host.UseSerilog(Settings.InitializeSerilog());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

Settings.DotEnv.Load();

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
