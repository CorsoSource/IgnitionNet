namespace CorsoSystems.IgnitionNet.History.Alarm
{
    public partial class AlarmEventDatum
    {
        public int? Id { get; set; }
        public string? PropName { get; set; }
        public int? DataType { get; set; }
        public long? IntValue { get; set; }
        public double? FloatValue { get; set; }
        public string? StringValue { get; set; }
    }
}
