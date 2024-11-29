using FEM.Application.DTOS;
using FEM.Application.Matches.Get;
using FEM.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FEM.Web.Controllers;

public class MatchesController : Controller
{

    private readonly IMediator _mediator;
    public MatchesController(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    [HttpGet("matches/filter")]
    public async Task<IEnumerable<MatchViewModel>> FilterMatches(string? std, string? edt, string? lm, string? st, string? tname)
    {
        DateTime startDate = new DateTime();
        DateTime? endDate = null;
        bool liveMatches = false;
        if (std != null)
            startDate = DateTime.ParseExact(std, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        if (edt != null)
            endDate = DateTime.ParseExact(edt, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        if (lm == "true")
            liveMatches = true;
        var query = new GetMatchesFilteredQuery(startDate, liveMatches, SortType.ASCENDING, endDate, tname);
        var data = await _mediator.Send(query);
        return data;
    }
}
