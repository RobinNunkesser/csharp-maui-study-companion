using System;
using System.Text.Json.Serialization;

namespace Italbytz.Infrastructure.OpenMensa
{
    public partial class Day
    {
        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }
    }
}