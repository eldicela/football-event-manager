

using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories
{
    public interface IPlayersRepository
    {
        Task AddAsync(Player player);
        Task<Player> GetByIdAsync(int id);
        Task<IEnumerable<Player>> GetPlayersByTeamIdsAsync(List<int> ids);
    }
}
