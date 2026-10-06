using BlazorIdentityApiDemo.Components;
using BlazorIdentityApiDemo.Data;
using BlazorIdentityApiDemo.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<TokenStore>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthorization();
builder.Services
.AddIdentityApiEndpoints<ApplicationUser>(options => {
options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IEmailSender<ApplicationUser>, FakeEmailSender>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
    .GetRequiredService<ApplicationDbContext>();

    db.Database.Migrate();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapCustomIdentityApi<ApplicationUser>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.MapGet("/generate-confirmation-link",
async (
string email,
UserManager<ApplicationUser> userManager) =>
{
    var user =
    await userManager.FindByEmailAsync(email);

    if (user is null)
    {
        return Results.NotFound();
    }

    var token =
    await userManager
    .GenerateEmailConfirmationTokenAsync(user);

    var encodedToken =
    WebUtility.UrlEncode(token);

    var confirmationUrl =
    $"https://localhost:7093/confirmEmail" +
    $"?userId={user.Id}" +
    $"&code={encodedToken}";

    return Results.Ok(confirmationUrl);
});
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapGet("/secure-info", () =>
{
    return Results.Ok("Authenticated User");
})
.RequireAuthorization();
app.Run();
