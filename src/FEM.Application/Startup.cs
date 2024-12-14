
using FEM.Application.FootballClubPlayer.Service;
using FEM.Application.Interfaces.Services;
using FEM.Application.Players.Service;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FEM.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        services.AddScoped<IServicesManager, ServicesManager>();
        
        return services;
    }
}
