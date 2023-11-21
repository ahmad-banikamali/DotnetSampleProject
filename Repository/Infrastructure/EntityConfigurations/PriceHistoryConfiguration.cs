using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Infrastructure;

internal class PriceHistoryConfiguration : IEntityTypeConfiguration<PriceHistory>
{
    public void Configure(EntityTypeBuilder<PriceHistory> builder)
    {
        builder
            .Property(x => x.Date)
            .HasConversion(v => v,
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}