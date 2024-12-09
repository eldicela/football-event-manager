

using FEM.Application.DTOS;

namespace FEM.Application.Interfaces.Services;

public interface IMatchStatisticsService
{
    void AddMatchStatisticsAsync(MatchStatisticsAddRequestModel model);
}
