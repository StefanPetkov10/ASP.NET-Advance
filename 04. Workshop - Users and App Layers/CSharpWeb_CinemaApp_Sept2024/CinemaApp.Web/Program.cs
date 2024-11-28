using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.Infrastructure.Extensions;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SQLServer")!;
string adminEmail = builder.Configuration.GetValue<string>("Administrator:Email")!;
string adminUsername = builder.Configuration.GetValue<string>("Administrator:Username")!;
string adminPassword = builder.Configuration.GetValue<string>("Administrator:Password")!;
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

/*builder.Services.AddScoped<IRepository<Movie, Guid>, BaseRepository<Movie, Guid>>();
builder.Services.AddScoped<IRepository<Cinema, Guid>, BaseRepository<Cinema, Guid>>();
builder.Services.AddScoped<IRepository<CinemaMovie, object>, BaseRepository<CinemaMovie, object>>();
builder.Services.AddScoped<IRepository<ApplicationUserMovie, object>, BaseRepository<ApplicationUserMovie, object>>();*/
builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
builder.Services.RegisterUserDefinedServices(typeof(IMovieService).Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

WebApplication app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

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

app.SeedAdministrator(adminEmail, adminUsername, adminPassword);

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