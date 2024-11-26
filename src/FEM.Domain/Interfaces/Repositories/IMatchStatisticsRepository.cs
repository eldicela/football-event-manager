
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IMatchStatisticsRepository
{
    Task AddAsync(MatchStatistics matchStatistics);
    Task<MatchStatistics> GetByMatchIdForTeamIdAsync(int matchId, int teamId);
}
