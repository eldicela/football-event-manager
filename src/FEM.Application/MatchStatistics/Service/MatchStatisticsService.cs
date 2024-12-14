

using FEM.Application.Cards.Create;
using FEM.Application.DTOS;
using FEM.Application.Goals.Create;
using FEM.Application.Interfaces.Services;
using FEM.Application.MatchStatistics.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.MatchStatistics.Service;

internal class MatchStatisticsService : IMatchStatisticsService
{
    private readonly IServicesManager _servicesManager;
    private readonly IMediator _mediator;
    public MatchStatisticsService(IServiceProvider serviceProvider)
    {
        _servicesManager = serviceProvider.GetRequiredService<IServicesManager>();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    public async Task AddMatchStatisticsAsync(CreateMatchStatisticsCommand mstatCommand, CreateGoalsListCommand? goals, CreateCardsListCommand? cards)
    {
        if (goals != null && cards != null)
        {
            //stats, goals and cards
          await  _servicesManager.WrapInTransactionAsync(async () =>
            {
                await _mediator.Send(mstatCommand);
                await _mediator.Send(goals);
                await _mediator.Send(cards);
            });
        }

        if (goals == null && cards == null)
        {
            //only stats
            await _mediator.Send(mstatCommand);
        }

        if (goals == null)
        {
            //stats and cards
           await _servicesManager.WrapInTransactionAsync(async () =>
            {
                await _mediator.Send(mstatCommand);
                await _mediator.Send(cards);
            });
        }

        if (cards == null)
        {
            //stats and goals
           await _servicesManager.WrapInTransactionAsync(async () =>
            {
                await _mediator.Send(mstatCommand);
                await _mediator.Send(goals);
            });
        }

    }
}
