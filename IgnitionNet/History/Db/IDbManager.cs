namespace CorsoSystems.IgnitionNet.History.Db
{
    public interface IDbManager
    {
        void PatchDatabase();
        public void PatchDatabase(ICollection<string> partitionNames);

        public string PatchPartition(string partitionName);
        abstract string PatchAlarmEventData { get; }
        abstract string PatchAlarmEvents { get; }
        abstract string PathSqlthAnnotations { get;  }
        abstract string PatchSqlthDrv { get; }
        abstract string PatchSqlthSce { get; }
        abstract string PatchSqlthScInfo { get; }
        abstract string PatchSqlthTe { get; }
    }
}