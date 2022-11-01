using CorsoSystems.IgnitionNet.History.Db;
using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.History
{
    public static class HistoryContextExtensions
    {
        public static IDbManager GetDbManager(this DbContext context, string schema = "public")
        {
            if (context.Database.IsNpgsql())
            {
                return new NpgsqlManager(context, schema);
            }

            throw new NotImplementedException($"{context.Database.ProviderName} is not a supported provider.");
        }

        public static void PatchDatabase(this DbContext context)
        {
            GetDbManager(context).PatchDatabase();
        }

        public static void PatchDatabase(this DbContext context, ICollection<string> partitionNames)
        {
            GetDbManager(context).PatchDatabase(partitionNames);
        }
    }
}
