

using FEM.Application.DTOS;

namespace FEM.Application.Interfaces.Services;

public interface IPlayersService
{
    Task<IEnumerable<Player>> GetPlayersByIdsAsync(List<int> ids);
}
