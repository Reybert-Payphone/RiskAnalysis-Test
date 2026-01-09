using MediatR;
using RiskScore.Domain.Abstractions;

namespace RiskScore.Application.Features.RiskAnalysis.Commands.CreateRiskAnalysis;

public record CreateRiskAnalysisCommand(
    string Name,
    string DocumentIdentity,
    decimal Amount
) : IRequest<Result>;
