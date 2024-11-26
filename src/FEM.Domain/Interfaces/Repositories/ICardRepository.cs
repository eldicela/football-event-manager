
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface ICardRepository
{
    Task AddAsync(Card card);
    Task<Card> GetByIdAsync(int id);
}
