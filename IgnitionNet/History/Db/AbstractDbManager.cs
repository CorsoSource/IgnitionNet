using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.History.Db
{
    public abstract class AbstractDbManager : IDbManager
    {
        protected readonly DbContext _context;

        protected AbstractDbManager(DbContext context)
        {
            _context = context;
        }

        public virtual void PatchDatabase()
        {
            using (_context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw(PatchAlarmEventData);
                _context.Database.ExecuteSqlRaw(PatchAlarmEvents);
                _context.Database.ExecuteSqlRaw(PathSqlthAnnotations);
                _context.Database.ExecuteSqlRaw(PatchSqlthDrv);
                _context.Database.ExecuteSqlRaw(PatchSqlthSce);
                _context.Database.ExecuteSqlRaw(PatchSqlthScInfo);
                _context.Database.ExecuteSqlRaw(PatchSqlthTe);

                _context.Database.CommitTransaction();
            }
        }

        public virtual void PatchDatabase(ICollection<string> partitionNames)
        {
            using (_context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                foreach (var partition in partitionNames)
                {
                    PatchPartition(partition);
                }

                PatchDatabase();
            }
        }

        public abstract string PatchPartition(string partitionName);

        public abstract string PatchAlarmEventData { get; }
        public abstract string PatchAlarmEvents { get; }
        public abstract string PathSqlthAnnotations { get; }
        public abstract string PatchSqlthDrv { get; }
        public abstract string PatchSqlthSce { get; }
        public abstract string PatchSqlthScInfo { get; }
        public abstract string PatchSqlthTe { get; }
    }
}
