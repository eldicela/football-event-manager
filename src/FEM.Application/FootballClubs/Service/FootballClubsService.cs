

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Services;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubs.Service;

internal class FootballClubsService : IFootballClubsService
{
    private readonly IUnitOfWork _unitOfWork;
    public FootballClubsService(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }
    public async Task<FootballClub> GetFootballClubByIdAsync(int id)
    {
        var club = await _unitOfWork.FootballClubRepository.GetByIdAsync(id);
        return new FootballClub
        {
            Id = club.Id,
            Name = club.Name,
            Type = club.Type
        };
    }
}
