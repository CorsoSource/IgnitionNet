namespace CorsoSystems.IgnitionNet.History.Db
{
    public interface IDbManager
    {
        void PatchDatabase();
        void PatchDatabase(ICollection<string> partitionNames);

        string PatchPartition(string partitionName);
        string PatchAlarmEventData { get; }
        string PatchAlarmEvents { get; }
        string PatchHistoricalTagAnnotations { get;  }
        string PatchHistoricalDriver { get; }
        string PatchHistoricalScanClassExecution { get; }
        string PatchHistoricalScanClass { get; }
        string PatchHistoricalTag { get; }
    }
}