using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Matches.Update
{
    internal class UpdateMatchStatusCommandHandler : ICommandHandler<UpdateMatchStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMatchStatusCommandHandler(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public async Task<Unit> Handle(UpdateMatchStatusCommand request, CancellationToken cancellationToken)
        {
            var match = await _unitOfWork.MatchRepositry.GetByIdAsync(request.Id);
            match.Status = request.Status;

            _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
