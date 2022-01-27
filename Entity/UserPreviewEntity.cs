using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class UserPreviewEntity
    {
        [JsonPropertyName("user")]
        public UserEntity User { get; set; } = default!;

        [JsonPropertyName("illusts")]
        public List<IllustEntity> Illusts { get; set; } = default!;

        [JsonPropertyName("is_muted")]
        public bool IsMuted { get; set; }
    }
}
