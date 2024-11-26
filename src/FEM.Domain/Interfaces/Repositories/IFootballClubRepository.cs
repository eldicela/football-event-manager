
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IFootballClubRepository
{
    Task AddAsync(FootballClub club);
    Task<FootballClub> GetByIdAsync(int id);
}
