
using FEM.Domain.Enums;

namespace FEM.Application.DTOS;

public class FootballClub
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ClubType Type { get; set; }
}

public class FootballClubAddRequestModel
{
    public string Name { get; set; }
    public ClubType Type { get; set; }
}

public class FootballClubPlayerAddRequestModel
{
    public int ClubId { get; set; }
    public bool IsNewPlayer { get; set; }
    public int PlayerId { get; set; }
    public PlayerAddRequestModel Player { get; set; }

}