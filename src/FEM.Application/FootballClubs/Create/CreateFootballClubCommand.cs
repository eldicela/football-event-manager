using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Enums;


namespace FEM.Application.FootballClubs.Create;

public class CreateFootballClubCommand : ICommand<int>
{

    public string Name { get; set; }
    public ClubType Type { get; set; } 
    
    public CreateFootballClubCommand(string name, ClubType type)
    {
        Name = name;
        Type = type;
    }

}
