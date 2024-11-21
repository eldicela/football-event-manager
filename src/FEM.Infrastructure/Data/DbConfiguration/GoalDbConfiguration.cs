
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration;

internal class GoalDbConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.ToTable("Goals");

        builder.HasKey(x => x.Id);  

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
