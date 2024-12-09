

using FEM.Application.Interfaces.Messaging;

namespace FEM.Application.FootballClubPlayer.Get;

public class GetPlayerIdsByTeamIdQuery : IQuery<List<int>>
{
    public int FootballClubId { get; set; }
}
