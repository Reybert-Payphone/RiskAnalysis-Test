namespace RiskScore.SharedKernel.Errors;

public record UnauthorizedError(string Code, string Message) : Error(Code, Message)
{
}
