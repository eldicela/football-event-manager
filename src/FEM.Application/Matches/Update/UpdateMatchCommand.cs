

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;
using MediatR;
using System.Windows.Input;

namespace FEM.Application.Matches.Update;

internal class UpdateMatchCommand : ICommand<Unit>
{

    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int? CategoryId { get; set; }
    public MatchStatus Status { get; set; }

    public UpdateMatchCommand(int id, DateTime date, int? categoryId, MatchStatus status)
    {
        Id = id;
        Date = date;
        CategoryId = categoryId;
        Status = status;
    }

}
