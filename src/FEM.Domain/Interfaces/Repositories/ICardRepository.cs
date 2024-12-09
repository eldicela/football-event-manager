
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface ICardRepository
{
    Task AddAsync(Card card);
    Task AddRangeAsync(List<Card> cards);
    Task<Card> GetByIdAsync(int id);
    Task<IEnumerable<Card>> GetCardsByMatchAndTeamIdAsync(int matchId, int teamId);
}
