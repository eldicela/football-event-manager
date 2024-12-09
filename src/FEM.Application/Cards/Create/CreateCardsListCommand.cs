

using FEM.Application.Interfaces.Messaging;
using MediatR;

namespace FEM.Application.Cards.Create;

public class CreateCardsListCommand : ICommand<Unit>
{
    public CreateCardsListCommand(List<CreateCardCommand> cardCommands)
    {
        CardCommands = cardCommands;
    }

    public List<CreateCardCommand> CardCommands { get; set; }
}


