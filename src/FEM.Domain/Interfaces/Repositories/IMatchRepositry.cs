
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IMatchRepositry
{
    Task AddAsync(Match match);   
    Task<Match> GetByIdAsync(int id);
}
