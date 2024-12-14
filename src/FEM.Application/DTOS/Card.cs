

using FEM.Domain.Enums;

namespace FEM.Application.DTOS;

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

public class CardAddRequestModel
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
    public int IssuedMinute { get; set; }
    public string Reason { get; set; }
    public string TypeString { get; set; } 
    public CardType Type { get; set; }
}
