using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class TrendingTagsDTO
    {
        [JsonPropertyName("trend_tags")]
        public List<TrendTagData> TrendTags { get; set; } = default!;

        public sealed class TrendTagData
        {
            [JsonPropertyName("tag")]
            public string Tag { get; set; } = default!;

            [JsonPropertyName("translated_name")]
            public string? TranslatedName { get; set; }

            [JsonPropertyName("illust")]
            public IllustEntity Illust { get; set; } = default!;
        }
    }
}
