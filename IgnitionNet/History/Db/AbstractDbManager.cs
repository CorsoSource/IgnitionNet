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

        public virtual void EnsureDatabase()
        {
            using (_context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw(EnsureAlarmEventData);
                _context.Database.ExecuteSqlRaw(EnsureAlarmEvents);
                _context.Database.ExecuteSqlRaw(EnsureSqlthAnnotations);
                _context.Database.ExecuteSqlRaw(EnsureSqlthDrv);
                _context.Database.ExecuteSqlRaw(EnsureSqlthSce);
                _context.Database.ExecuteSqlRaw(EnsureSqlthScInfo);
                _context.Database.ExecuteSqlRaw(EnsureSqlthTe);

                _context.Database.CommitTransaction();
            }
        }

        public virtual void EnsureDatabase(ICollection<string> partitionNames)
        {
            using (_context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                foreach (var partition in partitionNames)
                {
                    EnsurePartition(partition);
                }

                EnsureDatabase();
            }
        }

        public abstract string EnsurePartition(string partitionName);

        public abstract string EnsureAlarmEventData { get; }
        public abstract string EnsureAlarmEvents { get; }
        public abstract string EnsureSqlthAnnotations { get; }
        public abstract string EnsureSqlthDrv { get; }
        public abstract string EnsureSqlthSce { get; }
        public abstract string EnsureSqlthScInfo { get; }
        public abstract string EnsureSqlthTe { get; }
    }
}
