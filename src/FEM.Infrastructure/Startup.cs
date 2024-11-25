

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using FEM.Domain.Interfaces.Services;
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

        services.AddDefaultIdentity<User>(opt => opt.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<FEMDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient<IEmailSender, EmailSender.EmailSender>();

        return services;
    }
}
