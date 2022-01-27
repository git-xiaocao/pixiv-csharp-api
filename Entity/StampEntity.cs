using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class StampEntity
    {
        [JsonPropertyName("stamp_id")]
        public int StampId { get; set; }

        [JsonPropertyName("stamp_url")]
        public string StampUrl { get; set; } = default!;
    }
}
