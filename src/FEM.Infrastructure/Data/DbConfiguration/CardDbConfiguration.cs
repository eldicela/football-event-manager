
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class CardDbConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Reason)
            .HasMaxLength(100);

        builder.HasOne<MatchStatistics>()
            .WithMany()
            .HasForeignKey(x => new {x.MatchId, x.TeamId})
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(x => x.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
