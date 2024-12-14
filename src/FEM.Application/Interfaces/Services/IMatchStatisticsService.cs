

using FEM.Application.Cards.Create;
using FEM.Application.DTOS;
using FEM.Application.Goals.Create;
using FEM.Application.MatchStatistics.Create;

namespace FEM.Application.Interfaces.Services;

public interface IMatchStatisticsService
{
    Task AddMatchStatisticsAsync(CreateMatchStatisticsCommand mstatCommand, CreateGoalsListCommand? goals, CreateCardsListCommand? cards);
}
