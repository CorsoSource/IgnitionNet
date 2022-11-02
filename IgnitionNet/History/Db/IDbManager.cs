namespace CorsoSystems.IgnitionNet.History.Db
{
    public interface IDbManager
    {
        void PatchDatabase();
        void PatchDatabase(ICollection<string> partitionNames);
        void PatchPartition(string partitionName);
        string PatchPartitionQuery(string partitionName);
        string PatchAlarmEventDataQuery { get; }
        string PatchAlarmEventsQuery { get; }
        string PatchHistoricalTagAnnotationsQuery { get;  }
        string PatchHistoricalDriverQuery { get; }
        string PatchHistoricalScanClassExecutionQuery { get; }
        string PatchHistoricalScanClassQuery { get; }
        string PatchHistoricalTagQuery { get; }
    }
}