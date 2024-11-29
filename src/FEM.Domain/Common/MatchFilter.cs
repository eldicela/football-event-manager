

using FEM.Domain.Enums;

namespace FEM.Domain.Common;

public class MatchFilter
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? TeamName { get; set; }
    public bool Live { get; set; }  
    public SortType Sort { get; set; }
}
