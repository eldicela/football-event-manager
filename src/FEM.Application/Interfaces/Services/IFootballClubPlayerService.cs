

namespace FEM.Application.Interfaces.Services;

public interface IFootballClubPlayerService
{
    Task<List<int>> GetPlayersIdsByTeamId(int teamId);
}
