using RiskScore.Domain.Abstractions;

namespace RiskScore.Application.Shared.Services.ScoreService;

public interface IScoreService
{
    Task<Result<ScoreServiceModel>> CalculateRiskScore(string name, string documentIdentity, decimal amount);
}
