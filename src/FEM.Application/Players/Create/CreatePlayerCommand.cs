
using FEM.Application.Interfaces.Messaging;

namespace FEM.Application.Players.Create;

internal class CreatePlayerCommand : ICommand<int>
{

    public string Name { get; set; }
    public DateTime Birthdate { get; set; }

    public CreatePlayerCommand(string name, DateTime birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
}
