
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IMatchStatisticsRepository
{
    Task AddAsync(MatchStatistics matchStatistics);
    Task<IEnumerable<MatchStatistics>> GetByMatchIdAsync(int matchId);
    Task<MatchStatistics> GetByMatchIdForTeamIdAsync(int matchId, int teamId);
}
