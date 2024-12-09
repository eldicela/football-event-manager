

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class CardRepository : ICardRepository
{
    private readonly DbSet<Card> _dbSet;
    public CardRepository(FEMDbContext context)
    {
        _dbSet = context.Set<Card>();
    }
    public async Task AddAsync(Card card)
    {
        await _dbSet.AddAsync(card);
    }

    public async Task AddRangeAsync(List<Card> cards)
    {
       await _dbSet.AddRangeAsync(cards);
    }

    public async Task<Card> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Card with id: {id} doesn't exists");
    }

    public async Task<IEnumerable<Card>> GetCardsByMatchAndTeamIdAsync(int matchId, int teamId)
    {
        return await _dbSet.Where(x => x.MatchId == matchId && x.TeamId == teamId)
            .ToListAsync();
    }
}
