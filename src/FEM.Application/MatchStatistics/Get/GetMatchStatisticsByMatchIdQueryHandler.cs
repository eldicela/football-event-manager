

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;
using FEM.Application.Interfaces.Services;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.MatchStatistics.Get;

internal class GetMatchStatisticsByMatchIdQueryHandler : IQueryHandler<GetMatchStatisticsByMatchIdQuery, List<MatchStatisticsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServicesManager _servicesManager;
    public GetMatchStatisticsByMatchIdQueryHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        _servicesManager = serviceProvider.GetRequiredService<IServicesManager>();
    }

    public async Task<List<MatchStatisticsViewModel>> Handle(GetMatchStatisticsByMatchIdQuery request, CancellationToken cancellationToken)
    {
        var match = await _servicesManager.MatchesService.GetMatchByIdAsync(request.MatchId);
        var matchStatistics = await _unitOfWork.MatchStatisticsRepository.GetByMatchIdAsync(request.MatchId);
        var matchStatViewModelList = new List<MatchStatisticsViewModel>();


        foreach (var item in matchStatistics)
        {
            var goals = await _unitOfWork.GoalRepository.GetGoalsByMatchAndTeamIdAsync(item.MatchId, item.TeamId);
            var cards = await _unitOfWork.CardRepository.GetCardsByMatchAndTeamIdAsync(item.MatchId, item.TeamId);
            var team = await _servicesManager.FootballClubsService.GetFootballClubByIdAsync(item.TeamId);
            var playersIds = await _servicesManager.FootballClubPlayersService.GetPlayersIdsByTeamId(item.TeamId);
            var players = await _servicesManager.PlayersService.GetPlayersByIdsAsync(playersIds);


            var goalsDto = goals.Select(x => new DTOS.Goal
            {
                Id = x.Id,
                MatchId = x.MatchId,
                TeamId = x.TeamId,
                Minute = x.Minute,
                PlayerId = x.PlayerId,
                Type = x.Type,
            }).ToList();

            var cardsDto = cards.Select(x => new DTOS.Card
            {
                Id = x.Id,
                MatchId = x.MatchId,
                TeamId = x.TeamId,
                PlayerId = x.PlayerId,
                IssuedMinute = x.IssuedMinute,
                Reason = x.Reason,
                Type = x.Type,
            }).ToList();

            matchStatViewModelList.Add(new MatchStatisticsViewModel
            {
                Match = match, 
                Team = team,
                Players = players.ToList(),
                Corners = item.Corners,
                Posession = item.Posession,
                Goals = goalsDto,
                Cards = cardsDto,
            });

        }

        return matchStatViewModelList;
    }
}
