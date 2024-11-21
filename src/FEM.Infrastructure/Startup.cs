

using FEM.Domain.Interfaces.Repositories;
using FEM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FEMDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FootballEManager")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
