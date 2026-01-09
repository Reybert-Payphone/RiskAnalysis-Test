using System.Reflection;

namespace RiskScore.ArchitectureTests.Infrastructure;

public class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(Application.DependencyInjection).Assembly;
    protected static readonly Assembly DomainAssembly = typeof(RiskScore.Domain.Abstractions.Result).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(RiskScore.Infrastructure.DependencyInjection).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
