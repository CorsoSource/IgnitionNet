using CorsoSystems.IgnitionNet.Entities.TagHistory;
using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.Db;

public class PartitionContext : DbContext
{
    private readonly string _partionName;
    public virtual DbSet<HistoricalTagDatum> HistoricalTagData { get; set; } = null!;

    public PartitionContext(string partitionName)
    {
        _partionName = partitionName;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricalTagDatum>(entity =>
        {
            entity.Metadata.SetIsTableExcludedFromMigrations(true);

            entity.ToTable(_partionName)
                 .HasNoKey();
            entity.Property(e => e.TagId)
                .HasColumnName("tagid");
            entity.Property(e => e.IntValue)
                .HasColumnName("intvalue");
            entity.Property(e => e.FloatValue)
                .HasColumnName("floatvalue");
            entity.Property(e => e.StringValue)
                .HasColumnName("stringvalue");
            entity.Property(e => e.DateValue)
                .HasColumnName("datevalue");
            entity.Property(e => e.DataIntegrity)
                .HasColumnName("dataintegrity");
            entity.Property(e => e.TimeStamp)
                .HasColumnName("t_stamp");
        });
    }
}
