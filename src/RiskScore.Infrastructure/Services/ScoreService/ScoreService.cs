using RiskScore.Application.Shared.Services.ScoreService;
using RiskScore.Domain.Abstractions;

namespace RiskScore.Infrastructure.Services.ScoreService;

public class ScoreService : IScoreService
{
    public Task<Result<ScoreServiceModel>> CalculateRiskScore(string name, string documentIdentity, decimal amount) => throw new NotImplementedException();
}
