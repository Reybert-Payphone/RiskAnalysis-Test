using Microsoft.EntityFrameworkCore;
using RiskScore.Domain.Abstractions;
using RiskScore.Domain.Entities;

namespace RiskScore.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(
        DbContextOptions options
        ) : base(options) { }

    public DbSet<RiskAnalysis> RiskAnalyses => Set<RiskAnalysis>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
        )
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
