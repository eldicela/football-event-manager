using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FEM.Web.Areas.Admin.Controllers;

public class FootballClubsController : Controller
{
    private readonly IMediator _mediator;
    public FootballClubsController(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //[HttpPost]
    //public async Task<IActionResult> Create()
    //{
       
    //    return RedirectToAction(nameof(Index));
    //}
}
