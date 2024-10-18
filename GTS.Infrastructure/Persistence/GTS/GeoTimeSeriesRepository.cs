using GTS.Domain.GTS;

namespace GTS.Infrastructure.Persistence.GTS;

public class GeoTimeSeriesRepository(AppDbContext context) : BaseRepository<GeoTimeSeries>(context), IGeoTimeSeriesRepository
{
}
