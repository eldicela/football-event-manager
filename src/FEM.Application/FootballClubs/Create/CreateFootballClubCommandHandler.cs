

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubs.Create;

internal class CreateFootballClubCommandHandler : ICommandHandler<CreateFootballClubCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateFootballClubCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }
    public async Task<int> Handle(CreateFootballClubCommand request, CancellationToken cancellationToken)
    {
        var club = new Domain.Entities.FootballClub { 
             Name = request.Name,
             Type = request.Type,
        };
        await _unitOfWork.FootballClubRepository.AddAsync(club);
        await _unitOfWork.CommitAsync(cancellationToken);
        return club.Id;
    }
}
