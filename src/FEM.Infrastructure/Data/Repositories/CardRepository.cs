

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
    public async Task Add(Card card)
    {
        await _dbSet.AddAsync(card);
    }

    public async Task<Card> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Card with id: {id} doesn't exists");
    }
}
