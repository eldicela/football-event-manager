using FEM.Application.Matches.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FEM.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public class HomeController : Controller
{
    private readonly IMediator _mediator;
    public HomeController(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();        
    }

    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
        var query = new GetMatchesFilteredQuery(DateTime.Now, false, Domain.Enums.SortType.ASCENDING, null, null);
        var results = await _mediator.Send(query);

        return View(results.Select(x => new Application.DTOS.MatchViewModel
        {
            Id = x.Id,
            Date = x.Date,
            CategoryId = x.CategoryId,
            Status = x.Status,
            Team1 = new Application.DTOS.FootballClub
            {
                Id = x.Team1.Id,
                Name = x.Team1.Name,
                Type = x.Team1.Type,
            },
            Team2 = new Application.DTOS.FootballClub
            {
                Id = x.Team2.Id,
                Name = x.Team2.Name,
                Type = x.Team2.Type,
            }
        }).ToList());
    }
}
