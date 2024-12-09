
namespace FEM.Application.DTOS;

public class MatchStatistics
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public byte Corners { get; set; }
    public decimal Posession { get; set; }
}

public class MatchStatisticsAddRequestModel
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public byte Corners { get; set; }
    public decimal Posession { get; set; }
    public List<GoalAddRequestModel> Goals { get; set; }
    public List<CardAddRequestModel> Cards { get; set; }
}

public class MatchStatisticsViewModel
{
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public byte Corners { get; set; }
    public decimal Posession { get; set; }
    public List<Goal> Goals { get; set; }
    public List<Card> Cards { get; set; }
}