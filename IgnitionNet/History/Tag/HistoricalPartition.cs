namespace CorsoSystems.IgnitionNet.History.Tag
{
    public partial class HistoricalPartition
    {
        public string PartitionName { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public HistoricalDriver Driver { get; set; } = null!;
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int BlockSize { get; set; }
        public int? Flags { get; set; }
    }
}
