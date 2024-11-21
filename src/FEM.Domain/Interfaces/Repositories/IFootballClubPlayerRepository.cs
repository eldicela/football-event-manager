

using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IFootballClubPlayerRepository
{
    Task Add(FootballClubPlayer footballClubPlayer);
}
