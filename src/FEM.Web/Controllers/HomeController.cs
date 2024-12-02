using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FEM.Web.Models;
using FEM.Application.Matches.Get;
using MediatR;

namespace FEM.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(IServiceProvider serviceProvider, ILogger<HomeController> logger)
    {
        _logger = logger;
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
