

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.MatchStatistics.Create;

internal class CreateMatchStatisticsCommandHandler : ICommandHandler<CreateMatchStatisticsCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMatchStatisticsCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<Unit> Handle(CreateMatchStatisticsCommand request, CancellationToken cancellationToken)
    {
        var matchStatistics = new Domain.Entities.MatchStatistics
        {
            MatchId = request.MatchId,
            TeamId = request.TeamId,
            Corners = request.Corners,
            Posession = request.Possesion
        };

        await _unitOfWork.MatchStatisticsRepository.AddAsync(matchStatistics);
        //await _unitOfWork.CommitAsync(cancellationToken);
        _unitOfWork.Commit();
        return Unit.Value;
    }

}
