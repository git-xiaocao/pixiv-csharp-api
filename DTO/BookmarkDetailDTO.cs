using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class BookmarkDetailDTO
    {
        [JsonPropertyName("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = default!;

        [JsonPropertyName("restrict")]
        public string Restrict { get; set; }=default!;
    }
}
