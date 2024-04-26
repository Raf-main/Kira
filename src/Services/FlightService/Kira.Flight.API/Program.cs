using Kira.Flight.API.Middleware;
using Kira.Flight.Extensions;

using Light.Infrastructure.EfCore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<IDatabaseMigrationApplier>().ApplyMigrations();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
app.UseCustomExceptionHandler();

app.UseCors(opts => { opts.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
