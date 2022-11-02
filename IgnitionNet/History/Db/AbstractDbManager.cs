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
                _context.Database.ExecuteSqlRaw(PatchAlarmEventDataQuery);
                _context.Database.ExecuteSqlRaw(PatchAlarmEventsQuery);
                _context.Database.ExecuteSqlRaw(PatchHistoricalTagAnnotationsQuery);
                _context.Database.ExecuteSqlRaw(PatchHistoricalDriverQuery);
                _context.Database.ExecuteSqlRaw(PatchHistoricalScanClassExecutionQuery);
                _context.Database.ExecuteSqlRaw(PatchHistoricalScanClassQuery);
                _context.Database.ExecuteSqlRaw(PatchHistoricalTagQuery);

                _context.Database.CommitTransaction();
            }
        }

        public virtual void PatchDatabase(ICollection<string> partitionNames)
        {
            using (_context.Database.CurrentTransaction ?? _context.Database.BeginTransaction())
            {
                foreach (var partition in partitionNames)
                {
                    PatchPartitionQuery(partition);
                }

                PatchDatabase();
            }
        }

        public virtual void PatchPartition(string partitionName)
        {
            _context.Database.ExecuteSqlRaw(PatchPartitionQuery(partitionName));
        }

        public abstract string PatchPartitionQuery(string partitionName);

        public abstract string PatchAlarmEventDataQuery { get; }
        public abstract string PatchAlarmEventsQuery { get; }
        public abstract string PatchHistoricalTagAnnotationsQuery { get; }
        public abstract string PatchHistoricalDriverQuery { get; }
        public abstract string PatchHistoricalScanClassExecutionQuery { get; }
        public abstract string PatchHistoricalScanClassQuery { get; }
        public abstract string PatchHistoricalTagQuery { get; }
    }
}
