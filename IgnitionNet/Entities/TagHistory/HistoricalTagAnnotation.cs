namespace CorsoSystems.IgnitionNet.Entities.TagHistory
{
    public partial class HistoricalTagAnnotation
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public HistoricalTag Tag { get; set; } = default!;
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
        public string? Type { get; set; }
        public string? DataValue { get; set; }
        public string? AnnotationId { get; set; }
    }
}
