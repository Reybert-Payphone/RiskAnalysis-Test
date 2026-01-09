using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiskScore.Domain.Entities;

namespace RiskScore.Infrastructure.Persistence.Configurations;

public class RiskAnalysisConfiguration : IEntityTypeConfiguration<RiskAnalysis>
{
    public void Configure(EntityTypeBuilder<RiskAnalysis> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.HasKey(ra => ra.Id);
        builder.Property(ra => ra.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(ra => ra.DocumentIdentity)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(ra => ra.Score)
            .IsRequired();
    }
}
