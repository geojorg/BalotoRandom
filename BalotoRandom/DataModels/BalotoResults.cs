using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BalotoRandom.DataModels
{
    public partial class BalotoResults
    {
        [JsonPropertyName("sorteos")]
        public Sorteo[] Sorteos { get; set; }
    }

    public partial class Sorteo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("sorteo")]
        public long SorteoSorteo { get; set; }

        [JsonPropertyName("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonPropertyName("b1")]
        public long? B1 { get; set; }

        [JsonPropertyName("b2")]
        public long? B2 { get; set; }

        [JsonPropertyName("b3")]
        public long? B3 { get; set; }

        [JsonPropertyName("b4")]
        public long? B4 { get; set; }

        [JsonPropertyName("b5")]
        public long? B5 { get; set; }

        [JsonPropertyName("b6")]
        public long? B6 { get; set; }

        [JsonPropertyName("bcayo")]
        public long Bcayo { get; set; }

        [JsonPropertyName("bacumulado")]
        public long Bacumulado { get; set; }

        [JsonPropertyName("r1")]
        public long? R1 { get; set; }

        [JsonPropertyName("r2")]
        public long? R2 { get; set; }

        [JsonPropertyName("r3")]
        public long? R3 { get; set; }

        [JsonPropertyName("r4")]
        public long? R4 { get; set; }

        [JsonPropertyName("r5")]
        public long? R5 { get; set; }

        [JsonPropertyName("r6")]
        public long? R6 { get; set; }

        [JsonPropertyName("rcayo")]
        public long Rcayo { get; set; }

        [JsonPropertyName("racumulado")]
        public long Racumulado { get; set; }

        [JsonPropertyName("nuevo")]
        public long Nuevo { get; set; }

        [JsonPropertyName("link_video")]
        public object LinkVideo { get; set; }
    }
    public partial class BalotoResults
    {
        public static BalotoResults FromJson(string json) => JsonSerializer.Deserialize<BalotoResults>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this BalotoResults self) => JsonSerializer.Serialize(self);
    }
}
