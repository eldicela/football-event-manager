
using FEM.Domain.Enums;
using FEM.Application.Interfaces.Messaging;

namespace FEM.Application.Matches.Get;

public class GetMatchesFilteredQuery : IQuery<IEnumerable<DTOS.MatchViewModel>>
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? TeamName { get; set; }
    public bool Live { get; set; }
    public SortType SortType { get; set; }

    public GetMatchesFilteredQuery(DateTime std, bool live, SortType sortType, DateTime? endDate, string? teamName)
    {
        StartDate = std;
        Live = live;
        SortType = sortType;
        EndDate = endDate;
        TeamName = teamName;
    }

}
