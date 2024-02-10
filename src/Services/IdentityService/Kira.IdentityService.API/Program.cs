using Kira.IdentityService.API.Data.Contexts;
using Kira.IdentityService.API.Data.Models;
using Kira.IdentityService.API.Data.Repositories;
using Kira.IdentityService.API.Data.Repositories.Interfaces;
using Kira.IdentityService.API.Data.Services;
using Kira.IdentityService.API.Data.Services.Interfaces;
using Kira.IdentityService.API.Middleware;
using Kira.IdentityService.API.Services;
using Kira.IdentityService.API.Services.Interfaces;
using Kira.Security.Shared.Jwt.Extensions;
using Kira.Security.Shared.Jwt.Options;
using Kira.Security.Shared.Jwt.Services;
using Kira.Utils.Shared.Cookie;
using Kira.Utils.Shared.Time;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// options
var jwtOptionsSection = builder.Configuration.GetSection(JwtOptions.OptionsKey);
var jwtOptions = jwtOptionsSection.Get<JwtOptions>();
builder.Services.Configure<JwtOptions>(jwtOptionsSection);

if (jwtOptions == null)
{
    throw new NullReferenceException(nameof(jwtOptions));
}

var identityConnectionString = builder.Configuration.GetConnectionString("Identity");

// logging
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
// utils
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddScoped<ICookieService, CookieService>();

// db
builder.Services.AddDbContext<IdentityServerDbContext>(options =>
{
    options.UseNpgsql(identityConnectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
    });
});

builder.Services.AddScoped<DbContext, IdentityServerDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IDatabaseMigrationApplier, DatabaseMigrationApplier>();

// services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddJwtAuthentication(jwtOptions);

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<IdentityServerDbContext>();

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Identity API" });
});

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<IDatabaseMigrationApplier>().ApplyMigrations();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });

app.UseCors(opts => { opts.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });

app.UseCustomExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();