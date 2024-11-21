
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FEM.Infrastructure;

public sealed class FEMDbContext : DbContext
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
