

using FEM.Application.Interfaces.Messaging;
using MediatR;

namespace FEM.Application.MatchStatistics.Create
{
    public class CreateMatchStatisticsCommand : ICommand<Unit>
    {

        public int MatchId { get; set; }
        public int TeamId { get; set; } 
        public byte Corners {  get; set; }
        public decimal Possesion { get; set; }

        public CreateMatchStatisticsCommand(int matchId, int teamId, byte corners, decimal possesion)
        {
            MatchId = matchId;
            TeamId = teamId;
            Corners = corners;
            Possesion = possesion;
        }
    }
}
