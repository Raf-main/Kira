using Kira.Security.Shared.Jwt.Extensions;
using Kira.Security.Shared.Jwt.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// options
var jwtOptions = builder.Configuration.Get<JwtOptions>();

if (jwtOptions == null)
{
    throw new NullReferenceException(nameof(jwtOptions));
}

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddJwtAuthentication(jwtOptions);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

await app.UseOcelot();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();