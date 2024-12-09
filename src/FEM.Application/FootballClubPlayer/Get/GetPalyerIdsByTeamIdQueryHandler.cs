
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubPlayer.Get;

public class GetPalyerIdsByTeamIdQueryHandler : IQueryHandler<GetPlayerIdsByTeamIdQuery, List<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public GetPalyerIdsByTeamIdQueryHandler(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }
    public async Task<List<int>> Handle(GetPlayerIdsByTeamIdQuery request, CancellationToken cancellationToken)
    {
       var playerIds =  await _unitOfWork.FootballClubPlayerRepository.GetPlayersIdsByTeamIdAsync(request.FootballClubId);
       return playerIds.ToList();
    }
}
