
using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;

namespace FEM.Application.Matches.Get;

public class GetMatchesByTeamNameQuery : IQuery<IEnumerable<MatchViewModel>>
{
    public GetMatchesByTeamNameQuery(string teamName)
    {
        TeamName = teamName;
    }

    public string TeamName { get; set; }
}
