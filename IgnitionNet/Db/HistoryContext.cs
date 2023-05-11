using CorsoSystems.IgnitionNet.Entities.Alarming;
using CorsoSystems.IgnitionNet.Entities.TagHistory;
using Microsoft.EntityFrameworkCore;

namespace CorsoSystems.IgnitionNet.Db;

public class HistoryContext : DbContext
{
    public HistoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricalTag>(entity =>
        {
            entity.ToTable("sqlth_te", "public");

            entity.HasIndex(e => e.TagPath, "sqlth_tetagpathndx");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Created).HasColumnName("created");

            entity.Property(e => e.DataType).HasColumnName("datatype");

            entity.Property(e => e.QueryMode).HasColumnName("querymode");

            entity.Property(e => e.Retired).HasColumnName("retired");

            entity.Property(e => e.ScanClassId).HasColumnName("scid");

            entity.Property(e => e.TagPath)
                .HasMaxLength(255)
                .HasColumnName("tagpath");
        });

        modelBuilder.Entity<AlarmEvent>(entity =>
        {
            entity.ToTable("alarm_events", "public");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.DisplayPath)
                .HasMaxLength(255)
                .HasColumnName("displaypath");

            entity.Property(e => e.EventFlags).HasColumnName("eventflags");

            entity.Property(e => e.EventId)
                .HasMaxLength(255)
                .HasColumnName("eventid");

            entity.Property(e => e.EventTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("eventtime");

            entity.Property(e => e.EventType).HasColumnName("eventtype");

            entity.Property(e => e.Priority).HasColumnName("priority");

            entity.Property(e => e.Source)
                .HasMaxLength(255)
                .HasColumnName("source");
        });

        modelBuilder.Entity<AlarmEventDatum>(entity =>
        {

            entity.ToTable("alarm_event_data", "public");

            entity.HasIndex(e => e.Id, "alarm_event_dataidndx");

            entity.Property(e => e.DataType).HasColumnName("dtype");

            entity.Property(e => e.FloatValue).HasColumnName("floatvalue");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IntValue).HasColumnName("intvalue");

            entity.Property(e => e.PropName)
                .HasMaxLength(255)
                .HasColumnName("propname");

            entity.Property(e => e.StringValue).HasColumnName("strvalue");
        });

        modelBuilder.Entity<HistoricalTagDatum>(entity =>
        {
            entity.ToTable("sqlth_data", t => t.ExcludeFromMigrations());

            entity.HasNoKey();
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

        modelBuilder.Entity<HistoricalTagAnnotation>(entity =>
        {
            entity.ToTable("sqlth_annotations", "public");

            entity.HasIndex(e => e.EndTime, "sqlth_annotationsend_timendx");

            entity.HasIndex(e => e.StartTime, "sqlthannotationsstarttimendx");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.AnnotationId)
                .HasMaxLength(255)
                .HasColumnName("annotationid");

            entity.Property(e => e.DataValue)
                .HasMaxLength(255)
                .HasColumnName("datavalue");

            entity.Property(e => e.EndTime).HasColumnName("end_time");

            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.Property(e => e.TagId).HasColumnName("tagid");

            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<HistoricalDriver>(entity =>
        {
            entity.ToTable("sqlth_drv", "public");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Provider)
                .HasMaxLength(255)
                .HasColumnName("provider");
        });

        modelBuilder.Entity<HistoricalPartition>(entity =>
        {
            entity.HasKey(entity => entity.PartitionName);
            entity.ToTable("sqlth_partitions", "public");

            entity.Property(e => e.BlockSize).HasColumnName("blocksize");

            entity.Property(e => e.DriverId).HasColumnName("drvid");

            entity.Property(e => e.EndTime).HasColumnName("end_time");

            entity.Property(e => e.Flags).HasColumnName("flags");

            entity.Property(e => e.PartitionName)
                .HasMaxLength(255)
                .HasColumnName("pname");

            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<HistoricalScanClassExecution>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("sqlth_sce", "public");

            entity.HasIndex(e => e.EndTime, "sqlth_sceend_timendx");

            entity.HasIndex(e => e.StartTime, "sqlth_scestart_timendx");

            entity.Property(e => e.EndTime).HasColumnName("end_time");

            entity.Property(e => e.Rate).HasColumnName("rate");

            entity.Property(e => e.ScanClassId).HasColumnName("scid");

            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<HistoricalScanClass>(entity =>
        {
            entity.ToTable("sqlth_scinfo", "public");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.DriverId).HasColumnName("drvid");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("scname");
        });
    }

    public virtual DbSet<AlarmEvent> AlarmEvents { get; set; } = null!;
    public virtual DbSet<AlarmEventDatum> AlarmEventData { get; set; } = null!;
    public virtual DbSet<HistoricalTagAnnotation> HistoricalTagAnnotations { get; set; } = null!;
    public virtual DbSet<HistoricalDriver> HistoricalDrivers { get; set; } = null!;
    public virtual DbSet<HistoricalPartition> HistoricalPartitions { get; set; } = null!;
    public virtual DbSet<HistoricalScanClass> HistoricalScanClasses { get; set; } = null!;
    public virtual DbSet<HistoricalTag> HistoricalTags { get; set; } = null!;
    public virtual DbSet<HistoricalTagDatum> HistoricalTagData { get; set; } = null!;
    public virtual DbSet<HistoricalScanClassExecution> HistoricalScanClassExecutions { get; set; } = null!;
}
