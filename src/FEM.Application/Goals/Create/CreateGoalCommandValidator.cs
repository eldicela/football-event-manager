using FluentValidation;

namespace FEM.Application.Goals.Create;

public class CreateGoalCommandValidator : AbstractValidator<CreateGoalCommand>
{
    public CreateGoalCommandValidator()
    {
        RuleFor(x => x.MatchId).NotEmpty().WithMessage("Match Id cannot be null or empty");
        RuleFor(x => x.TeamId).NotEmpty().WithMessage("Team Id cannot be null or empty");
        RuleFor(x => x.PlayerId).NotEmpty().WithMessage("Player Id cannot be empty");
        RuleFor(x => x.Minute).NotEmpty().WithMessage("Minnute cannot be empty or zero");
        RuleFor(x => x.Type).IsInEnum();
    }

}
