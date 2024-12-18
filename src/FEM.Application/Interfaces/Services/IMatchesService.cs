
using FEM.Application.DTOS;

namespace FEM.Application.Interfaces.Services;

public interface IMatchesService
{
    Task<Match> GetMatchByIdAsync(int id);
}
