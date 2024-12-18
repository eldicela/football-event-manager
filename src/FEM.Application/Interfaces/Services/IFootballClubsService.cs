

using FEM.Application.DTOS;

namespace FEM.Application.Interfaces.Services
{
    public interface IFootballClubsService
    {
        Task<FootballClub> GetFootballClubByIdAsync(int id);
    }
}
