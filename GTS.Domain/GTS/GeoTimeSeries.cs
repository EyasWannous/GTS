using GTS.Domain.Bases;

namespace GTS.Domain.GTS;

public class GeoTimeSeries : BaseEntity
{
    public string ClassName { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public ICollection<DataPoint> Points { get; set; } = new HashSet<DataPoint>();
}
