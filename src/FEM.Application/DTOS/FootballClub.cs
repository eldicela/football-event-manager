
using FEM.Domain.Enums;

namespace FEM.Application.DTOS;

public class FootballClub
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ClubType Type { get; set; }
}
