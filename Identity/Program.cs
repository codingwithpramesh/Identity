using Identity.Data;
using Identity.Data.Repo;
using Identity.Models;
using Identity.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        option.EnableDetailedErrors();
    }
);
//builder.Services.AddDbContext<ApplicationDbContext>();
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
   //         .AddEntityFrameworkStores<ApplicationDbContext>()
     //       .AddDefaultTokenProviders();

//builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

//for identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(

    config =>
    {
        config.Password.RequiredLength =6;
        config.Password.RequireDigit = false;
        config.Password.RequireNonAlphanumeric = false;
        config.SignIn.RequireConfirmedEmail = true;
        config.Password.RequireUppercase = false;
    }
    ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(op => op.LoginPath="/Account/Login");


builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name ="Cookies";
    config.LoginPath = "Account/Login";
});


//builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
