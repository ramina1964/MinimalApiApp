  var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Todo: Add MudBlazor Nuget package and use it in this project.

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IUserModel, DisplayUserModel>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
