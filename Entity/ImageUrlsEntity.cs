using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class ImageUrlsEntity
    {
        [JsonPropertyName("square_medium")]
        public string SquareMedium { get; set; } = default!;

        [JsonPropertyName("medium")]
        public string Medium { get; set; } = default!;

        [JsonPropertyName("large")]
        public string Large { get; set; }= default!;

        [JsonPropertyName("original")]
        public string? Original { get; set; }   
    }
}
