
using FEM.Application.DTOS;
using FEM.Application.Interfaces.Services;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Matches.Service
{
    internal class MatchesService : IMatchesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MatchesService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
        public async Task<Match> GetMatchByIdAsync(int id)
        {
            var match = await _unitOfWork.MatchRepositry.GetByIdAsync(id);
            return new Match
            {
                Id = match.Id,
                CategoryId = match.CategoryId,
                Date = match.Date,
                Status = match.Status,
                Team1 = match.Team1,
                Team2 = match.Team2,
            };
        }
    }
}
