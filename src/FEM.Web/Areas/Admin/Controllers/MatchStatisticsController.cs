using FEM.Domain.Enums;
using FEM.Application.Cards.Create;
using FEM.Application.DTOS;
using FEM.Application.Goals.Create;
using FEM.Application.Interfaces.Services;
using FEM.Application.MatchStatistics.Create;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FEM.Web.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
public class MatchStatisticsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateMatchStatisticsCommand> _validator;
    private readonly IServicesManager _servicesManager;
    private readonly IValidator<CreateGoalsListCommand> _goalsListComValidator;
    private readonly IValidator<CreateCardsListCommand> _cardsListComValidator;

    public MatchStatisticsController(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _validator = serviceProvider.GetRequiredService<IValidator<CreateMatchStatisticsCommand>>();
        _goalsListComValidator = serviceProvider.GetRequiredService<IValidator<CreateGoalsListCommand>>();
        _cardsListComValidator = serviceProvider.GetRequiredService<IValidator<CreateCardsListCommand>>();
        _servicesManager = serviceProvider.GetRequiredService<IServicesManager>();
    }

    [Area("Admin")]
    public IActionResult Index()
    {
        return View();
    }

    [Area("Admin")]
    [HttpGet]
    public async Task<IActionResult> Create(int? matchId, int? teamId)
    {
        // get players
        if (matchId == null || matchId <= 0 || teamId == null || teamId <= 0)
            return RedirectToAction(nameof(Index));

        var ids = await _servicesManager.FootballClubPlayersService.GetPlayersIdsByTeamId(teamId.Value);
        var players = await _servicesManager.PlayersService.GetPlayersByIdsAsync(ids);
        ViewBag.Players = players;

        return View(new MatchStatisticsAddRequestModel
        {
            MatchId = matchId.Value,
            TeamId = teamId.Value
        });

    }

    [Area("Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MatchStatisticsAddRequestModel model)
    {
        model.Goals = model.Goals.Select(x =>
        {
            x.Type = Enum.Parse<GoalType>(x.TypeString);
            return x;
        }).ToList();

        model.Cards = model.Cards.Select(x =>
        {
            x.Type = Enum.Parse<CardType>(x.TypeString);
            return x;
        }).ToList();

        var command = new CreateMatchStatisticsCommand(model.MatchId, model.TeamId, model.Corners, model.Posession);

        var goalCommands = model.Goals.Select(x => new CreateGoalCommand(x.MatchId, x.TeamId, x.PlayerId, x.Minute, x.Type)).ToList();
        var cardsCommands = model.Cards.Select(x => new CreateCardCommand(x.MatchId, x.TeamId, x.PlayerId, x.IssuedMinute, x.Reason, x.Type)).ToList();

        var goalsListCommands = new CreateGoalsListCommand(goalCommands);
        var cardsListCommands = new CreateCardsListCommand(cardsCommands);

        ValidationResult valResults = await _validator.ValidateAsync(command);

        if (!model.Goals.Any() || !model.Cards.Any())
        {

            if (!valResults.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { error = true, model = model, errors = new { matchStatistics = valResults.Errors } });
            }
            await _servicesManager.MatchStatisticsService.AddMatchStatisticsAsync(command, null, null);
            return Json(new { error = false, message = "Match statistics created successfully" });
        }

        if (model.Goals.Any() && model.Cards.Any())
        {
            ValidationResult goalsFinalResults = await _goalsListComValidator.ValidateAsync(goalsListCommands);
            ValidationResult cardsFinalResults = await _cardsListComValidator.ValidateAsync(cardsListCommands);

            if (!goalsFinalResults.IsValid || !valResults.IsValid || !cardsFinalResults.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { error = true, model = model, errors = new { matchStatistics = valResults.Errors, cards = cardsFinalResults.Errors, goals = goalsFinalResults.Errors } });
            }
            await _servicesManager.MatchStatisticsService.AddMatchStatisticsAsync(command, goalsListCommands, cardsListCommands);

            return Json(new { error = false, message = "Match statistics created successfully" });
        }

        if (model.Goals.Any())
        {

            ValidationResult goalsResults = await _goalsListComValidator.ValidateAsync(goalsListCommands);

            if (!goalsResults.IsValid || !valResults.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { error = true, model = model, errors = new { matchStatistics = valResults.Errors, goals = goalsResults.Errors } });
            }

            await _servicesManager.MatchStatisticsService.AddMatchStatisticsAsync(command, goalsListCommands, null);

            return Json(new { error = false, message = "Match statistics created successfully" });
        }

        if (model.Cards.Any())
        {

            ValidationResult cardsResults = await _cardsListComValidator.ValidateAsync(cardsListCommands);

            if (!valResults.IsValid || !cardsResults.IsValid)
            {
                Response.StatusCode = 400;
                return Json(new { error = true, model = model, errors = new { matchStatistics = valResults.Errors, cards = cardsResults.Errors } });
            }

            await _servicesManager.MatchStatisticsService.AddMatchStatisticsAsync(command, null, cardsListCommands);
          
            return Json(new { error = false, message = "Match statistics created successfully" });
        }

        return BadRequest();
    }
}
