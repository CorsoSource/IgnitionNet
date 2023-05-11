namespace CorsoSystems.IgnitionNet.Entities.TagHistory;

public partial class HistoricalPartition
{
    public string PartitionName { get; set; } = default!;
    public int DriverId { get; set; }
    public HistoricalDriver Driver { get; set; } = default!;
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public int BlockSize { get; set; }
    public int? Flags { get; set; }
}
