using RiskScore.Domain.Abstractions;

namespace RiskScore.Domain.Entities;

public class RiskAnalysis : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public string DocumentIdentity { get; set; } = default!;
    public decimal Amount { get; set; }
    public int Score { get; set; }
    public int Status { get; set; }

    public static RiskAnalysis Create(
        string name,
        string documentIdentity,
        decimal amount,
        int score
        )
    {
        return new RiskAnalysis
        {
            Name = name,
            DocumentIdentity = documentIdentity,
            Amount = amount,
            Score = score,
            Status = ValidateStatus(score, amount)
        };
    }

    private static int ValidateStatus(int score, decimal amount)
    {
        return (score, amount) switch
        {
            (>= 700, > 0) => 1,
            (>= 500 and < 700, < 1000) => 1,
            ( < 500, > 0) => 2,
            _ => 2
        };
    }
}
