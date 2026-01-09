using MediatR;
using Microsoft.Extensions.Logging;
using RiskScore.Application.Shared.Services.ScoreService;
using RiskScore.Domain.Abstractions;
using RiskScore.Domain.Repositories;

namespace RiskScore.Application.Features.RiskAnalysis.Commands.CreateRiskAnalysis;

internal sealed class CreateRiskAnalysisCommandHandler(
    IUnitOfWork _unitOfWork,
    IScoreService _scoreService,
    IRiskAnalysisRepository _riskAnalysisRepository,
    ILogger<CreateRiskAnalysisCommandHandler> _logger) : IRequestHandler<CreateRiskAnalysisCommand, Result>
{
    public async Task<Result> Handle(CreateRiskAnalysisCommand request, CancellationToken cancellationToken)
    {
        var score = await _scoreService.CalculateRiskScore(
            request.Name,
            request.DocumentIdentity,
            request.Amount
            );

        var riskAnalysis = Domain.Entities.RiskAnalysis.Create(
            request.Name,
            request.DocumentIdentity,
            request.Amount
            );
    }
}
