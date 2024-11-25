
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FEM.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(assembly));

        return services;
    }
}
