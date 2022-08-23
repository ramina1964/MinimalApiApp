using BlazorServerUI.Data;
using DataAccess.dbo.Data;
using DataAccess.dbo.DbAccess;
using DataAccess.dbo.Models;

var builder = WebApplication.CreateBuilder(args);

// Todo: Remove duplication of ConnectionStrings in appsettings.json by using the same property in appsettings.json of MinimalApi.

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IUserModel, DisplayUserModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
