using CorsoSystems.IgnitionNet.IgnitionTypes;
using System.Text.Json.Serialization;

namespace CorsoSystems.IgnitionNet.Entities.TagHistory
{
    public partial class HistoricalTag
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("tagpath")]
        public string TagPath { get; set; } = default!;
        [JsonPropertyName("scid")]
        public int ScanClassId { get; set; }
        [JsonIgnore]
        public HistoricalScanClass ScanClass { get; set; } = default!;
        [JsonPropertyName("datatype")]
        public DataTypeClass DataType { get; set; }
        [JsonPropertyName("querymode")]
        public int QueryMode { get; set; }
        [JsonPropertyName("created")]
        public long Created { get; set; }
        [JsonPropertyName("retired")]
        public long? Retired { get; set; }
    }
}
