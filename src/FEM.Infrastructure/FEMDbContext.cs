
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FEM.Infrastructure;

public sealed class FEMDbContext : IdentityDbContext<User, Role, int>
{
    public FEMDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
