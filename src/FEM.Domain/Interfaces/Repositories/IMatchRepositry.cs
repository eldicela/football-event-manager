
using FEM.Domain.Entities;
using FEM.Domain.Common;

namespace FEM.Domain.Interfaces.Repositories;

public interface IMatchRepositry
{
    Task AddAsync(Match match);   
    Task<Match> GetByIdAsync(int id);
    Task<IEnumerable<MatchWithClubs>> GetMatchesByTeamNameAsync(string teamName);
    Task<IEnumerable<MatchWithClubs>> GetMatchesFilterdAsync(MatchFilter filters);
}
