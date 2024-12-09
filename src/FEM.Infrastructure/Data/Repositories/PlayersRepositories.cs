

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class PlayersRepositories : IPlayersRepository
{
    private readonly DbSet<Player> _dbSet;
    public PlayersRepositories(FEMDbContext context)
    {
        _dbSet = context.Set<Player>();
    }

    public async Task AddAsync(Player player)
    {
        await _dbSet.AddAsync(player);
    }

    public async Task<Player> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Couldn't find player with id: {id}");
    }

    public async Task<IEnumerable<Player>> GetPlayersByTeamIdsAsync(List<int> ids)
    {
        var results = _dbSet.Where(x => ids.Contains(x.Id));
        return await results.ToListAsync();
    }
}
