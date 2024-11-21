
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IFootballClubRepository
{
    Task Add(FootballClub club);
    Task<FootballClub> GetByIdAsync(int id);
}
