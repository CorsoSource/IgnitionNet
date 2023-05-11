namespace CorsoSystems.IgnitionNet.Entities.Alarming;

public partial class AlarmEvent
{
    public int Id { get; set; }
    public string? EventId { get; set; }
    public string? Source { get; set; }
    public string? DisplayPath { get; set; }
    public int? Priority { get; set; }
    public int? EventType { get; set; }
    public int? EventFlags { get; set; }
    public DateTime? EventTime { get; set; }
}
