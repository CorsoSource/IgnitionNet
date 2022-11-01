namespace CorsoSystems.IgnitionNet.History.Db
{
    public interface IDbManager
    {
        void EnsureDatabase();
        public string EnsurePartition(string partitionName);
        public void EnsureDatabase(ICollection<string> partitionNames);
        abstract string EnsureAlarmEventData { get; }
        abstract string EnsureAlarmEvents { get; }
        abstract string EnsureSqlthAnnotations { get;  }
        abstract string EnsureSqlthDrv { get; }
        abstract string EnsureSqlthSce { get; }
        abstract string EnsureSqlthScInfo { get; }
        abstract string EnsureSqlthTe { get; }
    }
}