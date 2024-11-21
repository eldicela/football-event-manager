
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class FootballClubConfiguration : IEntityTypeConfiguration<FootballClub>
{
    public void Configure(EntityTypeBuilder<FootballClub> builder)
    {
        builder.ToTable("FootballClubs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
                .HasMaxLength(100);
    }
}
