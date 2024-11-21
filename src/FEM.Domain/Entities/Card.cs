
using FEM.Domain.Enums;

namespace FEM.Domain.Entities;

public class Card
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
    public int IssuedMinute { get; set; }
    public string Reason { get; set; }
    public CardType Type { get; set; }
}
