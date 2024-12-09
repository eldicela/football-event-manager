

using FEM.Application.Interfaces.Services;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.FootballClubPlayer.Service;

internal class FootballClubPlayerService : IFootballClubPlayerService
{
    private readonly IUnitOfWork _unitOfWork;

    public FootballClubPlayerService(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<List<int>> GetPlayersIdsByTeamId(int teamId)
    {
        var playersIds = await _unitOfWork.FootballClubPlayerRepository.GetPlayersIdsByTeamIdAsync(teamId);
        return playersIds.ToList();
    }
}
