using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.History
{
    public static class HistoryContextExtension
    {
        public static void EnsureHistoryTables(this DbContext context)
        {
            context.Database.ExecuteSqlRaw(Queries.EnsureAlarmEventData);
            context.Database.ExecuteSqlRaw(Queries.EnsureAlarmEvents);
            context.Database.ExecuteSqlRaw(Queries.EnsureSqlthAnnotations);
            context.Database.ExecuteSqlRaw(Queries.EnsureSqlthDrv);
            context.Database.ExecuteSqlRaw(Queries.EnsureSqlthSce);
            context.Database.ExecuteSqlRaw(Queries.EnsureSqlthScInfo);
            context.Database.ExecuteSqlRaw(Queries.EnsureSqlthTe);
        }
    }
}
