
using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubs.Get;

internal class GetAllFootballClubsQueryHandler : IQueryHandler<GetAllFootballClubsQuery, IEnumerable<FootballClub>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllFootballClubsQueryHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<IEnumerable<FootballClub>> Handle(GetAllFootballClubsQuery request, CancellationToken cancellationToken)
    {
        var clubs = await _unitOfWork.FootballClubRepository.GetAllAsync();
        return clubs.Select(x => new FootballClub
        {
            Id = x.Id,
            Name = x.Name,
            Type = x.Type,
        });
    }
}
