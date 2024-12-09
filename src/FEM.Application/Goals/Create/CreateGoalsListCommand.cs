

using FEM.Application.Interfaces.Messaging;
using MediatR;

namespace FEM.Application.Goals.Create;

public class CreateGoalsListCommand : ICommand<Unit>
{
    public CreateGoalsListCommand(List<CreateGoalCommand> goalsCommands)
    {
        GoalsCommands = goalsCommands;
    }

    public List<CreateGoalCommand> GoalsCommands { get; set; }
}
