

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class GoalsRepository : IGoalRepository
{
    private readonly DbSet<Goal> _dbSet;

    public GoalsRepository(FEMDbContext context)
    {
        _dbSet = context.Set<Goal>();
    }

    public async Task AddAsync(Goal goal)
    {
        await _dbSet.AddAsync(goal);
    }

    public async Task AddRangeAsync(List<Goal> goals)
    {
        await _dbSet.AddRangeAsync(goals);
    }

    public async Task<int> CountByMatchIdForTeamIdAsync(int matchId, int teamId)
    {
        return await _dbSet.Where(x => x.MatchId == matchId && x.TeamId == teamId).CountAsync();
    }

    public async Task<Goal> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Goal with id: {id} doesn't exists");
    }

    public async Task<IEnumerable<Goal>> GetGoalsByMatchAndTeamIdAsync(int matchId, int teamId)
    {
        return await _dbSet.Where(x => x.TeamId == teamId && x.MatchId == matchId).ToListAsync();
    }
}
