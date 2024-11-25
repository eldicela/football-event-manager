using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Identity.DbConfiguration;

internal class RoleDbConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(x => x.Id)
        .ValueGeneratedNever();
        builder.HasData(new Role
        {
            Id = 1,
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = "1"
        });
        builder.HasData(new Role
        {
            Id = 2,
            Name = "User",
            NormalizedName = "USER",
            ConcurrencyStamp = "2"
        });
    }
}
