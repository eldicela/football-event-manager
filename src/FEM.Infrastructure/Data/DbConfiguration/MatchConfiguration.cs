
using Microsoft.EntityFrameworkCore;
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Matches");

        builder.HasKey(x => x.Id);

        builder.HasOne<FootballClub>()
            .WithMany()
            .HasForeignKey(x => x.Team1)
            .OnDelete(DeleteBehavior.Restrict);
    
        builder.HasOne<FootballClub>()
            .WithMany()
            .HasForeignKey(x => x.Team2)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
