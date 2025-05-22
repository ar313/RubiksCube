using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RubiksCubeApi.Application;
using RubiksCubeApi.Infrastructure.Data;
using RubiksCubeApi.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ApplicationDB"));

builder.Services.AddControllers();
builder.Services.AddApplicationServices();

var rubiksUiOrigin = builder.Configuration["AllowedOrigins:RubiksUiApp"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowRubiksUiApp",
        policy =>
        {
            policy.WithOrigins(rubiksUiOrigin) // Angular app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowRubiksUiApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
