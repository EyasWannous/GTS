using GTS.Domain.Bases;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace GTS.Domain.GTS;

public class DataPoint : BaseEntity
{
    [Timestamp]
    public long TimeStamp { get; set; }
    public Point Point { get; set; } = Point.Empty;
    public long Elevation { get; set; }
    public string Value { get; set; } = string.Empty;
    public int GeoTimeSeriesId { get; set; }
    public required GeoTimeSeries GeoTimeSeries { get; set; }

    public override int GetHashCode()
        => TimeStamp.GetHashCode();
}
