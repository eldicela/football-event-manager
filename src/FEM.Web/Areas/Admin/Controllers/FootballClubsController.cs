using FEM.Application.DTOS;
using FEM.Application.FootballClubPlayer.Create;
using FEM.Application.FootballClubs.Create;
using FEM.Application.FootballClubs.Get;
using FEM.Application.Interfaces.Services;
using FEM.Application.Players.Create;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FEM.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public class FootballClubsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateFootballClubCommand> _footballClubCommandValidator;
    private readonly IServicesManager _servicesManager;
    public FootballClubsController(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _footballClubCommandValidator = serviceProvider.GetRequiredService<IValidator<CreateFootballClubCommand>>();
        _servicesManager = serviceProvider.GetRequiredService<IServicesManager>();
    }

    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
        var query = new GetAllFootballClubsQuery();
        var results = await _mediator.Send(query);

        return View(results);
    }

    [Area("Admin")]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [Area("Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(FootballClubAddRequestModel model)
    {
        var command = new CreateFootballClubCommand(model.Name, model.Type);

        ValidationResult valRes = await _footballClubCommandValidator.ValidateAsync(command);
        if (!valRes.IsValid)
        {
            foreach (var item in valRes.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }

        var clubId = await _mediator.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [Area("Admin")]
    [HttpGet]
    public IActionResult AddPlayer([FromRoute] int id)
    {
        return View(new FootballClubPlayerAddRequestModel
        {
            ClubId = id
        });
    }

    [Area("Admin")]
    public async Task<IActionResult> AddPlayer(FootballClubPlayerAddRequestModel model)
    {
        if (model.ClubId <= 0)
        {
            ModelState.AddModelError(string.Empty, "Club Id cannot be negative or zero");
            return View(model);
        };

        if (!model.IsNewPlayer)
        {
            if (model.PlayerId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Player id cannot be negative or zero");
                return View(model);
            }

            var addExisPlCommand = new AddPlayerToFootballClubCommand(model.ClubId, model.PlayerId);
            await _mediator.Send(addExisPlCommand);
            return RedirectToAction("Index");
        }


        var createPlayerCommand = new CreatePlayerCommand(model.Player.Name, model.Player.Birthdate);
        var newPlayerId = await _mediator.Send(createPlayerCommand);

        var addNewPlayerToClubComm = new AddPlayerToFootballClubCommand(model.ClubId, newPlayerId);
        await _mediator.Send(addNewPlayerToClubComm);

        return RedirectToAction(nameof(Index));

    }

    [Area("Admin")]
    [HttpGet]
    public async Task<IActionResult> ClubPlayers([FromRoute] int id)
    {
        var playerIds = await _servicesManager.FootballClubPlayersService.GetPlayersIdsByTeamId(id);
        var players = await _servicesManager.PlayersService.GetPlayersByIdsAsync(playerIds);

        return View(players);
    }
}
