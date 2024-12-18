
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IGoalRepository
{
    Task AddAsync(Goal goal);
    Task AddRangeAsync(List<Goal> goals);
    Task<int> CountByMatchIdForTeamIdAsync(int matchId, int TeamId);
    Task<Goal> GetByIdAsync(int id);
    Task<IEnumerable<Goal>> GetGoalsByMatchAndTeamIdAsync(int matchId, int teamId);
}
