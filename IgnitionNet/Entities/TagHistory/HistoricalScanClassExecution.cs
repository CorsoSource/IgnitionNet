namespace CorsoSystems.IgnitionNet.Entities.TagHistory;

public partial class HistoricalScanClassExecution
{
    public int? ScanClassId { get; set; }
    public HistoricalScanClass ScanClass { get; set; } = default!;
    public long? StartTime { get; set; }
    public long? EndTime { get; set; }
    public int? Rate { get; set; }
}
