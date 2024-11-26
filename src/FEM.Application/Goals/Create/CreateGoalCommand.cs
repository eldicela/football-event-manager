

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;

namespace FEM.Application.Goals.Create;

public class CreateGoalCommand : ICommand<int>
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
    public int Minute { get; set; }
    public GoalType Type { get; set; }
    public CreateGoalCommand(int matchId, int teamId, int playerId, int minute, GoalType type)
    {
        MatchId = matchId;
        TeamId = teamId;
        PlayerId = playerId;
        Minute = minute;
        Type = type;
    }

}
