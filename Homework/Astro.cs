using System.Text.Json.Serialization;
namespace Homework
{
    public class Astro
    {
        [JsonPropertyName("sunrise")]
        public string SunRise {  get; set; }
        [JsonPropertyName("sunset")]
        public string SunSet { get; set; }
        [JsonPropertyName("moonrise")]
        public string MoonRise { get; set; }
        [JsonPropertyName("moonset")]
        public string MoonSet { get; set; }
        [JsonPropertyName("moon_illumination")]
        public int MoonIllumination { get; set; }
    }
}
