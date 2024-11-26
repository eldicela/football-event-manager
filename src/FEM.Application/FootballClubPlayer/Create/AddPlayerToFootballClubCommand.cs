

using FEM.Application.Interfaces.Messaging;
using MediatR;

namespace FEM.Application.FootballClubPlayer.Create;

public class AddPlayerToFootballClubCommand : ICommand<Unit>
{

    public int ClubId { get; set; }
    public int PlayerId { get; set; }
    public AddPlayerToFootballClubCommand(int clubId, int playerId)
    {
        ClubId = clubId;
        PlayerId = playerId;
    }
}
