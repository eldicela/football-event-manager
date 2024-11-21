
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IMatchRepositry
{
    Task Add(Match match);   
    Task<Match> GetByIdAsync(int id);
}
