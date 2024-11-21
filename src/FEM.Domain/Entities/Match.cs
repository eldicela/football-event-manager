
using FEM.Domain.Enums;

namespace FEM.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public int Team1 {  get; set; }
    public int Team2 { get; set; }
    public MatchStatus Status { get; set; }
}
