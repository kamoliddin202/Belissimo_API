using System.Text;
using BusinessLogicLayer.Common;
using BusinessLogicLayer.IInterfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.IRepasitory;
using DataAccessLayer.Models;
using DataAccessLayer.Repasitories;
using DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();

//builder.Logging.AddLog4Net();

#region Seri Loggin configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

// user this line to override the built-in loggers  
//builder.Host.UseSerilog();

// use serilog for built-in loggers 
builder.Logging.AddSerilog();


//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region AddDbContext

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;   
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 7;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

#endregion

#region  Adding services to DI
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryInterface, CategoryRepasitory>();
builder.Services.AddTransient<IOrderInterface, OrderRepasitory>();
builder.Services.AddTransient<IOrderItemInterface, OrderItemRepasitory>();
builder.Services.AddTransient<IPromocodeInterface, PromocodeRepasitory>();
builder.Services.AddTransient<IProductInterface, ProductRepasitory>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>(); 

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedsAndDefaultAdminAsync(services);
}

app.UseSwagger ();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication ();
app.UseAuthorization();


app.MapControllers();

app.Run();



static async Task SeedsAndDefaultAdminAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if(! await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    var adminEmail = "admin@gmail.com";
    var adminPassword = "Admin.123$";

    var adminuser = await userManager.FindByEmailAsync(adminEmail);
    if (adminuser == null)
    {
        var newAdmin = new User
        {
            UserName = adminEmail,
            Email = adminEmail,
            FullName = "Abdulloh",
            EmailConfirmed = true,
            Address = "Tashkent"
            
        };

        var createAdmin = await userManager.CreateAsync(newAdmin, adminPassword);
        if (createAdmin.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }

        else
        {
            throw new CustomException("User yaratilmadi " + string.Join(';', createAdmin.Errors.Select(c => c.Description)));
        }
    }

}
