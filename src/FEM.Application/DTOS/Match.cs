

using FEM.Domain.Enums;

namespace FEM.Application.DTOS;

public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int? CategoryId { get; set; }
    public int Team1 { get; set; }
    public int Team2 { get; set; }
    public MatchStatus Status { get; set; }
}


public class MatchViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public MatchStatus Status { get; set; }
    public int? CategoryId { get; set; }
    public FootballClub Team1 { get; set; }
    public FootballClub Team2 { get; set; }
}

public class MatchAddRequestModel
{
    public DateTime Date { get; set; }
    public int? CategoryId { get; set; }
    public int Team1 { get; set; }
    public int Team2 { get; set; }
}