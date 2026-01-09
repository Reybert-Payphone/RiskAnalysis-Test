using FluentValidation;

namespace RiskScore.Application.Features.RiskAnalysis.Commands.CreateRiskAnalysis;

public class CreateRiskAnalysisCommandValidator : AbstractValidator<CreateRiskAnalysisCommand>
{
    public CreateRiskAnalysisCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.DocumentIdentity)
            .NotEmpty().WithMessage("Document Identity is required.")
            .MaximumLength(50).WithMessage("Document Identity must not exceed 50 characters.");
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");
    }
}
