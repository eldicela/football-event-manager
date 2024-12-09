
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IGoalRepository
{
    Task AddAsync(Goal goal);
    Task AddRangeAsync(List<Goal> goals);
    Task<Goal> GetByIdAsync(int id);
    Task<IEnumerable<Goal>> GetGoalsByMatchAndTeamIdAsync(int matchId, int teamId);
}
