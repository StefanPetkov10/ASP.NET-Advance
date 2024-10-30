using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SQLServer");

// Add services to the container.
builder.Services.AddDbContext<CinemaDbContext>(optins =>
{
    //Like OnConfiguration method

    optins.UseSqlServer(connectionString);
});

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
    {
        ConfigureIdentityOptions(builder, options);

    })
    .AddEntityFrameworkStores<CinemaDbContext>()
    .AddRoles<IdentityRole<Guid>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddUserManager<UserManager<ApplicationUser>>();
//.AddUserStore<ApplicationUser>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

WebApplication app = builder.Build();

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

//Authorization can work only if we know who uses the application -> We need Authentication
app.UseAuthentication(); // First -> Who am I?
app.UseAuthorization(); // Second -> What can I do?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Add routing to Identity Razor Pages.  

app.ApplyMigrations();
app.Run();

static void ConfigureIdentityOptions(WebApplicationBuilder builder, IdentityOptions configuration)
{
    configuration.Password.RequireDigit =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
    configuration.Password.RequireLowercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    configuration.Password.RequireUppercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    configuration.Password.RequireNonAlphanumeric =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    configuration.Password.RequiredLength =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
    configuration.Password.RequiredUniqueChars =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

    configuration.User.RequireUniqueEmail =
        builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");

    configuration.SignIn.RequireConfirmedEmail =
        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
    configuration.SignIn.RequireConfirmedPhoneNumber =
        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");
    configuration.SignIn.RequireConfirmedAccount =
        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
}