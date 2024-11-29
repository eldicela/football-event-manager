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

namespace FEM.Web.Areas.Admin.Controllers.MatchesController
{
    [Authorize(Roles = "Admin")]
    public class MatchesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateMatchCommand> _createMatchValidator;
        public MatchesController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
            _createMatchValidator = serviceProvider.GetRequiredService<IValidator<CreateMatchCommand>>();
        }

        [Area("Admin")]
        public async Task<IActionResult> Index(string date, byte live, byte sortType)
        {
            var today = new DateTime(2024, 12, 01);
            var liveMatches = false;
            var sort = SortType.ASCENDING;

            //var query = new GetMatchesFilteredQuery(today, liveMatches, sort);
            //var matches = await _mediator.Send(query);
            return View();
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

            return RedirectToAction("Index");
        }
    }
}
