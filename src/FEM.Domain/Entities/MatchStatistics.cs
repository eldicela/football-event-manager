
namespace FEM.Domain.Entities;

public class MatchStatistics
{
    public int MatchId { get; set; }
    public int TeamId {  get; set; }
    public byte Corners { get; set; }
    public decimal Posession { get; set; }
}
