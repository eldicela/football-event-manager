

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.MatchStatistics.Get;

internal class GetMatchStatisticsByMatchIdQueryHandler : IQueryHandler<GetMatchStatisticsByMatchIdQuery, List<MatchStatisticsViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetMatchStatisticsByMatchIdQueryHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<List<MatchStatisticsViewModel>> Handle(GetMatchStatisticsByMatchIdQuery request, CancellationToken cancellationToken)
    {
        var matchStatistics = await _unitOfWork.MatchStatisticsRepository.GetByMatchIdAsync(request.MatchId);

        var matchStatViewModel = matchStatistics.Select(async x =>
        {
            var goals = await _unitOfWork.GoalRepository.GetGoalsByMatchAndTeamIdAsync(x.MatchId, x.TeamId);
            var cards = await _unitOfWork.CardRepository.GetCardsByMatchAndTeamIdAsync(x.MatchId, x.TeamId);

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

            return new MatchStatisticsViewModel
            {
                MatchId = x.MatchId,
                TeamId = x.TeamId,
                Corners = x.Corners,
                Posession = x.Posession,
                Goals = goalsDto,
                Cards = cardsDto,
            };
        });

        var model = await Task.WhenAll(matchStatViewModel);

        return  model.ToList();
    }
}
