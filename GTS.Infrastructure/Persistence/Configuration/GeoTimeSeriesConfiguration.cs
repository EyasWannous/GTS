using GTS.Domain.GTS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTS.Infrastructure.Persistence.Configuration;

public class GeoTimeSeriesConfiguration : IEntityTypeConfiguration<GeoTimeSeries>
{
    public void Configure(EntityTypeBuilder<GeoTimeSeries> builder)
    {
        builder.HasIndex(geoTimeSeries => geoTimeSeries.ClassName);

        builder.HasMany(geoTimeSeries => geoTimeSeries.Points)
            .WithOne(point => point.GeoTimeSeries)
            .HasForeignKey(point => point.GeoTimeSeriesId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.ToTable("GeoTimeSeries");
    }
}
