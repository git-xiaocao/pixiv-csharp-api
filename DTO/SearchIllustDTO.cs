using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class SearchIllustDTO : IPixivListData
    {
        [JsonPropertyName("illusts")]
        public List<IllustEntity> Illusts { get; set; } = default!;

        [JsonPropertyName("search_span_limit")]
        public int SearchSpanLimit { get; set; }

        [JsonPropertyName("next_url")]
        public string? NextUrl { get; set; }
    }
}
