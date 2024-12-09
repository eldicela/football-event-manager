
using FluentValidation;

namespace FEM.Application.MatchStatistics.Create;

public class CreateMatchStatisticsCommandValidator : AbstractValidator<CreateMatchStatisticsCommand>
{
    public CreateMatchStatisticsCommandValidator()
    {
        RuleFor(x => x.MatchId).NotEmpty().WithMessage("Match Id cannot be empty or zero");

        RuleFor(x => x.TeamId).NotEmpty().WithMessage("Team Id cannot be empty or zero");

        byte zero = 0;
        RuleFor(x => x.Corners)
            .NotNull().WithMessage("Corners cannot be null")
            .GreaterThanOrEqualTo(zero).WithMessage("Corners cannot be negative");

        RuleFor(x => x.Possesion)
            .NotNull().WithMessage("Possesion cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Possesion cannot be less than 0%")
            .LessThanOrEqualTo(100).WithMessage("Possestion cannot be grater then 100%");
    }
}
