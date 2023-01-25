using System;
using System.Text.Json.Serialization;

namespace Italbytz.Infrastructure.OpenMensa
{
    public partial class Canteen
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("coordinates")]
        public double[] Coordinates { get; set; }
    }
}

