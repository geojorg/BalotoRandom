using System.Text.Json;
using System.Text.Json.Serialization;

namespace BalotoRandom.Models
{
    public partial class SearchResultModel
    {
        [JsonPropertyName("candidates")]
        public Candidate[] Candidates { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public partial class Candidate
    {
        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public partial class Geometry
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("viewport")]
        public Viewport Viewport { get; set; }
    }

    public partial class Location
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }

    public partial class Viewport
    {
        [JsonPropertyName("northeast")]
        public Location Northeast { get; set; }

        [JsonPropertyName("southwest")]
        public Location Southwest { get; set; }
    }

    public partial class SearchResultModel
    {
        public static SearchResultModel FromJson(string json) => JsonSerializer.Deserialize<SearchResultModel>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this SearchResultModel self) => JsonSerializer.Serialize(self);
    }
}
