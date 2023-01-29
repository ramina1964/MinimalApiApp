var builder = WebApplication.CreateBuilder(args);

// Todo: Consider removal of ConnectionStrings duplication in BlazorServerUI/secrets.json and MinimalApi/secrets.json
// Todo: Add MudBlazor Nuget package and use it in this project.

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IUserData, UserData>();
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
