
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class MatchStatisticsRepository : IMatchStatisticsRepository
{
    private readonly DbSet<MatchStatistics> _dbSet;

    public MatchStatisticsRepository(FEMDbContext context)
    {
        _dbSet = context.Set<MatchStatistics>();
    }

    public async Task AddAsync(MatchStatistics matchStatistics)
    {
        await _dbSet.AddAsync(matchStatistics);
    }
    public async Task<MatchStatistics> GetByMatchIdForTeamIdAsync(int matchId, int teamId)
    {
        return await _dbSet
            .Where(x => x.MatchId == matchId && x.TeamId == teamId)
            .FirstOrDefaultAsync() 
            ?? throw new Exception("Match statistics doesn't exists");
    }
}
