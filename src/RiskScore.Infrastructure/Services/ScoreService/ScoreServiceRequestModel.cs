namespace RiskScore.Application.Shared.Services.ScoreService;

public class ScoreServiceRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string DocumentIdentity { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
