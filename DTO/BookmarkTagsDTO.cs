using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class BookmarkTagsDTO : IPixivListData
    {
        [JsonPropertyName("bookmark_tags")]
        public List<BookmarkTagEntity> BookmarkTags { get; set; } = default!;

        [JsonPropertyName("next_url")]
        public string? NextUrl { get; set; }
    }
}
