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
                _context.Database.ExecuteSqlRaw(PatchHistoricalTagAnnotations);
                _context.Database.ExecuteSqlRaw(PatchHistoricalDriver);
                _context.Database.ExecuteSqlRaw(PatchHistoricalScanClassExecution);
                _context.Database.ExecuteSqlRaw(PatchHistoricalScanClass);
                _context.Database.ExecuteSqlRaw(PatchHistoricalTag);

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
        public abstract string PatchHistoricalTagAnnotations { get; }
        public abstract string PatchHistoricalDriver { get; }
        public abstract string PatchHistoricalScanClassExecution { get; }
        public abstract string PatchHistoricalScanClass { get; }
        public abstract string PatchHistoricalTag { get; }
    }
}
