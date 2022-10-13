namespace CorsoSystems.IgnitionNet.History.Tag
{
    public partial class HistoricalScanClassExecution
    {
        public int? ScanClassId { get; set; }
        public HistoricalScanClass ScanClass { get; set; }
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
        public int? Rate { get; set; }
    }
}
