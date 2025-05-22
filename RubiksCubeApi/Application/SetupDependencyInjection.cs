using Microsoft.EntityFrameworkCore;
using RubiksCubeApi.Application.Factories;
using RubiksCubeApi.Application.Interfaces;
using RubiksCubeApi.Application.Services;
using RubiksCubeApi.Infrastructure.Data;
using RubiksCubeApi.Infrastructure.Repositories;
using RubiksCubeApi.Infrastructure.UnitOfWork;

namespace RubiksCubeApi.Application
{
    public static class SetupDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRubiksCubeRepository, RubiksCubeRepository>();
            services.AddScoped<IRubiksCubeFactory, RubiksCubeFactory>();
            services.AddScoped<IRubiksCubeRotator, RubiksCubeRotator>();
            return services;
        }
    }
}
