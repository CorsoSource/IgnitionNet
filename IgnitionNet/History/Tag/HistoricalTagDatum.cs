namespace CorsoSystems.IgnitionNet.History.Tag
{
    public partial class HistoricalTagDatum
    {
        public int TagId { get; set; }
        public int? IntValue { get; set; }
        public double? FloatValue { get; set; }
        public string? StringValue { get; set; }
        public DateTime? DateValue { get; set; }
        public int? DataIntegrity { get; set; }
        public long TimeStamp { get; set; }
    }
}
