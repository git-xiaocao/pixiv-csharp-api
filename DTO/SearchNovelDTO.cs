using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class SearchNovelDTO : IPixivListData
    {
        [JsonPropertyName("novels")]
        public List<NovelEntity> Novels { get; set; } = default!;

        [JsonPropertyName("search_span_limit")]
        public int SearchSpanLimit { get; set; }

        [JsonPropertyName("next_url")]
        public string? NextUrl { get; set; }
    }
}
