using CorsoSystems.IgnitionNet.Entities.Internal;
using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.Db;

public static class InternalContextExtension
{
    public static void ConfigureConfigContext(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagHistorianProviderSetting>(entity =>
        {
            entity.Metadata.SetIsTableExcludedFromMigrations(true);

            entity.HasKey(e => e.ProfileId);

            entity.ToTable("TAGHISTORIANPROVIDERSETTINGS");

            entity.Property(e => e.ProfileId)
                .HasColumnType("NUMERIC(18,0)")
                .HasColumnName("PROFILEID");

            entity.Property(e => e.OptimizedPartitionsEnabled)
                .HasColumnType("BOOLEAN")
                .HasColumnName("OPTIMIZEDPARTITIONSENABLED")
                .HasDefaultValueSql("0");

            entity.Property(e => e.OptimizedWindowSizeSec)
                .HasColumnName("OPTIMIZEDWINDOWSIZESEC")
                .HasDefaultValueSql("60");

            entity.Property(e => e.PartitioningEnabled)
                .HasColumnType("BOOLEAN")
                .HasColumnName("PARTITIONINGENABLED")
                .HasDefaultValueSql("1");

            entity.Property(e => e.PartitionSize)
                .HasColumnName("PARTITIONSIZE")
                .HasDefaultValueSql("1");

            entity.Property(e => e.PartitionSizeUnits)
                .HasColumnType("VARCHAR(1024)")
                .HasColumnName("PARTITIONSIZEUNITS")
                .HasDefaultValueSql("'MONTH'");

            entity.Property(e => e.PruneAge)
                .HasColumnName("PRUNEAGE")
                .HasDefaultValueSql("1");

            entity.Property(e => e.PruneAgeUnits)
                .HasColumnType("VARCHAR(1024)")
                .HasColumnName("PRUNEAGEUNITS")
                .HasDefaultValueSql("'YEAR'");

            entity.Property(e => e.PruningEnabled)
                .HasColumnType("BOOLEAN")
                .HasColumnName("PRUNINGENABLED")
                .HasDefaultValueSql("0");

            entity.Property(e => e.StaleMultiplier)
                .HasColumnName("STALEMULTIPLIER")
                .HasDefaultValueSql("2");

            entity.Property(e => e.TrackScanClassExecutions)
                .HasColumnType("BOOLEAN")
                .HasColumnName("TRACKSCE")
                .HasDefaultValueSql("1");
        });
    }
}
