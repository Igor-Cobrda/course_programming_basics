using System.Text.Json.Serialization;
namespace Homework
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name {  get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }
}
