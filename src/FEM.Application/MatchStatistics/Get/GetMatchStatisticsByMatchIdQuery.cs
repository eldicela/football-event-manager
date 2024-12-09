

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;

namespace FEM.Application.MatchStatistics.Get;

public class GetMatchStatisticsByMatchIdQuery : IQuery<List<MatchStatisticsViewModel>>
{
    public int MatchId { get; set; }

    public GetMatchStatisticsByMatchIdQuery(int matchId)
    {
        MatchId = matchId;
    }
}


