


using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;
using MediatR;
using System.Windows.Input;

namespace FEM.Application.Matches.Update
{
    public class UpdateMatchStatusCommand : ICommand<Unit>
    {

        public int Id { get; set; }
        public MatchStatus Status { get; set; }

        public UpdateMatchStatusCommand(int id, MatchStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}
