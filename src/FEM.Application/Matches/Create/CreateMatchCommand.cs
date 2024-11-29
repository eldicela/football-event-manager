

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;

namespace FEM.Application.Matches.Create
{
    public record CreateMatchCommand(DateTime Date, int? CategoryId, int Team1, int Team2) : ICommand<int>
    {
        public CreateMatchCommand() : this(default, null, default, default)
        {

        }
    }
}
