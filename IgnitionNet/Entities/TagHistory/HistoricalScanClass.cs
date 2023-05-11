namespace CorsoSystems.IgnitionNet.Entities.TagHistory;

public partial class HistoricalScanClass
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int DriverId { get; set; }
    public HistoricalDriver Driver { get; set; } = default!;
}
