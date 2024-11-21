
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface ICardRepository
{
    Task Add(Card card);
    Task<Card> GetByIdAsync(int id);
}
