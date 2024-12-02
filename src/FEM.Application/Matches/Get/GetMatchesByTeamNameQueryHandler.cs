

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Matches.Get
{
    internal class GetMatchesByTeamNameQueryHandler : IQueryHandler<GetMatchesByTeamNameQuery, IEnumerable<MatchViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetMatchesByTeamNameQueryHandler(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();            
        }
        public async Task<IEnumerable<MatchViewModel>> Handle(GetMatchesByTeamNameQuery request, CancellationToken cancellationToken)
        {
           var matches = await _unitOfWork.MatchRepositry.GetMatchesByTeamNameAsync(request.TeamName);
            return matches.Select(x => new MatchViewModel
            {

                Id = x.Id,
                Date = x.Date,
                CategoryId = x.CategoryId,
                Status = x.Status,

                Team1 = new FootballClub
                {
                    Id = x.Team1.Id,
                    Name = x.Team1.Name,
                    Type = x.Team1.Type,
                },
                Team2 = new FootballClub
                {
                    Id = x.Team2.Id,
                    Name = x.Team2.Name,
                    Type = x.Team2.Type,
                }
            });
        }
    }
}
