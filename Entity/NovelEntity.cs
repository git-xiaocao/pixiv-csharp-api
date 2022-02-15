using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class NovelEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("caption")]
        public string Caption { get; set; } = default!;

        [JsonPropertyName("restrict")]
        public int Restrict { get; set; }

        [JsonPropertyName("x_restrict")]
        public int XRestrict { get; set; }

        [JsonPropertyName("is_original")]
        public bool IsOriginal { get; set; }

        [JsonPropertyName("image_urls")]
        public ImageUrlsEntity ImageUrls { get; set; } = default!;

        [JsonPropertyName("create_date")]
        public string CreateDate { get; set; } = default!;

        [JsonPropertyName("tags")]
        public List<TagEntity> Tags { get; set; } = default!;

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; }

        [JsonPropertyName("text_length")]
        public int TextLength { get; set; }

        [JsonPropertyName("user")]
        public UserEntity User { get; set; } = default!;

        [JsonPropertyName("series")]
        public SeriesEntity Series { get; set; } = default!;

        [JsonPropertyName("total_bookmarks")]
        public int TotalBookmarks { get; set; }

        [JsonPropertyName("is_bookmarked")]
        public int IsBookmarked { get; set; }

        [JsonPropertyName("total_view")]
        public int TotalView { get; set; }

        [JsonPropertyName("visible")]
        public bool Visible { get; set; }

        [JsonPropertyName("total_comments")]
        public int TotalComments { get; set; }

        [JsonPropertyName("is_muted")]
        public bool IsMuted { get; set; }

        [JsonPropertyName("is_mypixiv_only")]
        public bool IsMyPixivOnly { get; set; }

        [JsonPropertyName("is_x_restricted")]
        public bool IsXRestricted { get; set; }


        public sealed class SeriesEntity
        {
            public int? Id { get; set; }
            public string? Title { get; set; }
        }

    }
}
