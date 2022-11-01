namespace CorsoSystems.IgnitionNet.History.Db
{
    public interface IDbManager
    {
        void EnsureDatabase();
        abstract string EnsurePartition(string partitionName);
        abstract void EnsureDatabase(ICollection<string> partitionNames);
        public string EnsureAlarmEventData { get; }
        public string EnsureAlarmEvents { get; }
        abstract string EnsureSqlthAnnotations { get;  }
        abstract string EnsureSqlthDrv { get; }
        abstract string EnsureSqlthSce { get; }
        abstract string EnsureSqlthScInfo { get; }
        abstract string EnsureSqlthTe { get; }
    }
}