

using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class FootballClubPlayerDbConfiguration : IEntityTypeConfiguration<FootballClubPlayer>
{
    public void Configure(EntityTypeBuilder<FootballClubPlayer> builder)
    {
        builder.ToTable("FootballClubsPlayers");

        builder.HasKey(x => new { x.FootballClubId, x.PlayerId });

        builder.HasOne<FootballClub>()
            .WithMany()
            .HasForeignKey(x => x.FootballClubId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(x => x.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
