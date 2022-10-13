using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace CorsoSystems.IgnitionNet.Config.History
{
    public partial class TagHistorianProviderSetting
    {
        [JsonPropertyName("PROFILEID")]
        public int ProfileId { get; set; }
        [JsonPropertyName("PARTITIONINGENABLED")]
        public bool PartitioningEnabled { get; set; }
        
        [JsonPropertyName("PARTITIONSIZE")]
        public int PartitionSize { get; set; }
        
        [JsonPropertyName("PARTITIONSIZEUNITS")]
        public TimeUnits PartitionSizeUnits { get; set; }
        
        [JsonPropertyName("OPTIMIZEDPARTITIONSENABLED")]
        public bool OptimizedPartitionsEnabled { get; set; }
        [JsonPropertyName("OPTIMIZEDWINDOWSIZESEC")]

        public int OptimizedWindowSizeSec { get; set; }
        [JsonPropertyName("PRUNINGENABLED")]

        public bool PruningEnabled { get; set; }
        [JsonPropertyName("PRUNEAGE")]

        public int PruneAge { get; set; }
        [JsonPropertyName("PRUNEAGEUNITS")]

        public TimeUnits PruneAgeUnits { get; set; }
        [JsonPropertyName("TRACKSCE")]
        
        public bool TrackScanClassExecutions { get; set; }
        [JsonPropertyName("STALEMULTIPLIER")]
        public int StaleMultiplier { get; set; }
    }
}
