
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;

namespace FEM.Application.Cards.Create;

public class CreateCardCommand : ICommand<int>
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
    public int IssuedMinute { get; set; }
    public string Reason { get; set; }
    public CardType Type { get; set; }

    public CreateCardCommand(int matchId, int teamId, int playerId, int issuedMinute, string reason, CardType type)
    {
        MatchId = matchId;
        TeamId = teamId;
        PlayerId = playerId;
        IssuedMinute = issuedMinute;
        Reason = reason;
        Type = type;
    }
}
