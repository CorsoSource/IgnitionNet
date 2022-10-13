namespace CorsoSystems.IgnitionNet.History.Tag
{
    public partial class HistoricalScanClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int DriverId { get; set; }
        public HistoricalDriver Driver { get; set; } = null!;
    }
}
