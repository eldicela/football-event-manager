
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubPlayer.Create;

internal class AddPlayerToFootballClubCommandHandler : ICommandHandler<AddPlayerToFootballClubCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddPlayerToFootballClubCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<Unit> Handle(AddPlayerToFootballClubCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.footballClubPlayerRepository.AddAsync(new Domain.Entities.FootballClubPlayer
        {
            FootballClubId = request.ClubId,
            PlayerId = request.PlayerId,
        });  
        await _unitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
