

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Goals.Create;

internal class CreateGoalCommandHandler : ICommandHandler<CreateGoalCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateGoalCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();   
    }
    public async Task<int> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        var goal = new Goal
        {
            MatchId = request.MatchId,
            TeamId = request.TeamId,
            PlayerId = request.PlayerId,
            Minute = request.Minute,
            Type = request.Type,
        };
        await _unitOfWork.GoalRepository.AddAsync(goal);
        await _unitOfWork.CommitAsync(cancellationToken);
        return goal.Id;
    }
}
