using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FEM.Application.Matches.Get;
using FEM.Domain.Enums;
using FEM.Application.DTOS;
using FEM.Application.Matches.Create;
using FluentValidation;
using FluentValidation.Results;
using FEM.Application.FootballClubs.Get;
using Microsoft.AspNetCore.Http;
using FEM.Application.Matches.Update;
using FEM.Application.Interfaces.Services;

namespace FEM.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MatchesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateMatchCommand> _createMatchValidator;
        private readonly IServicesManager _servicesManager;
        public MatchesController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
            _createMatchValidator = serviceProvider.GetRequiredService<IValidator<CreateMatchCommand>>();
            _servicesManager = serviceProvider.GetRequiredService<IServicesManager>();
        }

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teamsQuery = new GetAllFootballClubsQuery();


            var clubs = await _mediator.Send(teamsQuery);
            ViewBag.Clubs = clubs;

            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(MatchAddRequestModel matchReqModel)
        {
            var command = new CreateMatchCommand(matchReqModel.Date, matchReqModel.CategoryId, matchReqModel.Team1, matchReqModel.Team2);

            ValidationResult valRes = await _createMatchValidator.ValidateAsync(command);
            if (!valRes.IsValid)
            {
                foreach (var x in valRes.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                var teamsQuery = new GetAllFootballClubsQuery();
                var clubs = await _mediator.Send(teamsQuery);
                ViewBag.Clubs = clubs;
                return View(matchReqModel);
            }

            var id = await _mediator.Send(command);
            Console.WriteLine("Created Match Id:", id);

            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] MatchUpdateStatusModel model)
        {
            if (model.Id <= 0) throw new Exception("Id cannot be negative or zero");
            var match = await _servicesManager.MatchesService.GetMatchByIdAsync(model.Id);
            if (match.Status == MatchStatus.FINNISHED) throw new Exception("Cannot change status, match is already finnished");

            var matchStat = Enum.Parse<MatchStatus>(model.Status);

            var command = new UpdateMatchStatusCommand(model.Id, matchStat);
            await _mediator.Send(command);

            return Json(new {error = false, message = "created successfully"});
        }
    }
}
