using Kira.Security.Shared.Jwt.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json", false, true).AddEnvironmentVariables();

var jwtOptions = builder.Configuration.Get<JwtOptions>();

if (jwtOptions == null)
{
    throw new NullReferenceException(nameof(jwtOptions));
}

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();

app.UseCors(opts => { opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseStaticFiles();

app.UseSwaggerForOcelotUI(opt => { opt.PathToSwaggerGenerator = "/swagger/docs"; });

app.UseOcelot().Wait();

app.Run();
