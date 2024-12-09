

using FluentValidation;

namespace FEM.Application.Goals.Create;

public class CreateGoalsListCommandValidator : AbstractValidator<CreateGoalsListCommand>
{
    public CreateGoalsListCommandValidator()
    {
        RuleForEach(x => x.GoalsCommands).SetValidator(new CreateGoalCommandValidator());
    }
}
