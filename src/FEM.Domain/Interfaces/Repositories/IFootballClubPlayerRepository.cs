

using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IFootballClubPlayerRepository
{
    Task AddAsync(FootballClubPlayer footballClubPlayer);
    Task<IEnumerable<int>> GetPlayersIdsByTeamIdAsync(int teamId);
}
