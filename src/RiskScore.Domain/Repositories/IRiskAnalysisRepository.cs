using RiskScore.Domain.Entities;
using WalletPayment.Domain.Abstractions;

namespace RiskScore.Domain.Repositories;

public interface IRiskAnalysisRepository : IAsyncRepository<RiskAnalysis>
{
}
