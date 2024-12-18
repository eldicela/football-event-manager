

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

            List<MatchViewModel> matchViewModel = new List<MatchViewModel>();

            foreach (var match in matches)
            {
                var t1Goals = await _unitOfWork.GoalRepository.CountByMatchIdForTeamIdAsync(match.Id, match.Team1.Id);
                var t2Goals = await _unitOfWork.GoalRepository.CountByMatchIdForTeamIdAsync(match.Id, match.Team2.Id);

                var vmm = new MatchViewModel
                {
                    Id = match.Id,
                    Date = match.Date,
                    CategoryId = match.CategoryId,
                    Status = match.Status,

                    Team1 = new FootballClub
                    {
                        Id = match.Team1.Id,
                        Name = match.Team1.Name,
                        Type = match.Team1.Type,
                    },
                    Team1Goals = t1Goals,
                    Team2 = new FootballClub
                    {
                        Id = match.Team2.Id,
                        Name = match.Team2.Name,
                        Type = match.Team2.Type,
                    },
                    Team2Goals = t2Goals, 
                };
                matchViewModel.Add(vmm);
            }
            return matchViewModel;
        }
    }
}
