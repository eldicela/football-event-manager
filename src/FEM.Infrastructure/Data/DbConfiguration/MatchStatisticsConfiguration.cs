
using FEM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FEM.Infrastructure.Data.DbConfiguration
{
    internal class MatchStatisticsConfiguration : IEntityTypeConfiguration<MatchStatistics>
    {
        public void Configure(EntityTypeBuilder<MatchStatistics> builder)
        {
            builder.ToTable("MatchesStatistics");

            builder.HasKey(x => new {x.MatchId, x.TeamId});

            builder.Property(X => X.Posession)
                .HasPrecision(5, 2);

            builder.HasOne<Match>()
                .WithMany()
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Restrict);
        
            builder.HasOne<FootballClub>()
                .WithMany()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
