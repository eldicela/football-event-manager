
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Matches.Update;

internal class UpdateMatchCommandHandler : ICommandHandler<UpdateMatchCommand, Unit>
{
    private IUnitOfWork _unitOfWork;
    public UpdateMatchCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }
    public async Task<Unit> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
    {
        var existingMatch = await _unitOfWork.MatchRepositry.GetByIdAsync(request.Id);
        existingMatch.Date = request.Date;
        existingMatch.CategoryId = request.CategoryId.Value;
        existingMatch.Status = request.Status;

        _unitOfWork.Commit();

        return Unit.Value;
    }
}
