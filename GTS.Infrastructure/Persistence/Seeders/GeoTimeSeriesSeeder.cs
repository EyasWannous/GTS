using GTS.Domain.GTS;

namespace GTS.Infrastructure.Persistence.Seeders;

public static class GeoTimeSeriesSeeder
{
    public static List<GeoTimeSeries> GetData()
    {
        List<GeoTimeSeries> data = [];

        data.AddRange(Array.Empty<GeoTimeSeries>());

        return data;
    }
}
