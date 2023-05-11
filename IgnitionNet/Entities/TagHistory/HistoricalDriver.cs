namespace CorsoSystems.IgnitionNet.Entities.TagHistory;

public partial class HistoricalDriver
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Provider { get; set; }
}
