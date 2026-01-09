using RiskScore.Domain.Entities;
using RiskScore.Domain.Repositories;
using WalletPayment.Infrastructure.Persistence.repositories;

namespace RiskScore.Infrastructure.Persistence.Repositories;

public class RiskAnalysisRepository : RepositoryBase<RiskAnalysis>, IRiskAnalysisRepository
{
    public RiskAnalysisRepository(ApplicationDbContext context) : base(context)
    {
    }
}
