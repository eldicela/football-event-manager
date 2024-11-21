
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class PlayerDbConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
                .HasMaxLength(150);

    }
}
