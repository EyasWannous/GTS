using GTS.Domain.GTS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTS.Infrastructure.Persistence.Configuration;

public class DataPointConfiguration : IEntityTypeConfiguration<DataPoint>
{
    public void Configure(EntityTypeBuilder<DataPoint> builder)
    {
        builder.HasIndex(dataPoint => dataPoint.TimeStamp);

        builder.ToTable("DataPoints");
    }
}
