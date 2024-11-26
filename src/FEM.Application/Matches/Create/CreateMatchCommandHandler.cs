

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;

namespace FEM.Application.Matches.Create
{
    internal class CreateMatchCommandHandler : ICommandHandler<CreateMatchCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMatchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var match = new Domain.Entities.Match
            {
                Team1 = request.Team1,
                Team2 = request.Team2,
                Date = request.Date,
                CategoryId = request.CategoryId,
                Status = Domain.Enums.MatchStatus.NOT_STARTED,
            };

            await _unitOfWork.MatchRepositry.AddAsync(match);
            await _unitOfWork.CommitAsync(cancellationToken);
            return match.Id;
        }
    }
}
