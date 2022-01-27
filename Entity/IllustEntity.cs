using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class IllustEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("image_urls")]
        public ImageUrlsEntity ImageUrls { get; set; } = default!;

        [JsonPropertyName("caption")]
        public string Caption { get; set; } = default!;

        [JsonPropertyName("restrict")]
        public int Restrict { get; set; } = default!;

        [JsonPropertyName("user")]
        public UserEntity User { get; set; } = default!;

        [JsonPropertyName("tags")]
        public List<TagEntity> Tags { get; set; } = default!;

        [JsonPropertyName("tools")]
        public List<string> Tools { get; set; } = default!;

        [JsonPropertyName("create_date")]
        public string CreateDate { get; set; } = default!;

        [JsonPropertyName("page_count")]
        public int PageCount { get; set; } = default!;

        [JsonPropertyName("width")]
        public int Width { get; set; } = default!;

        [JsonPropertyName("height")]
        public int Height { get; set; } = default!;

        [JsonPropertyName("sanity_level")]
        public int SanityLevel { get; set; } = default!;

        [JsonPropertyName("x_restrict")]
        public int XRestrict { get; set; } = default!;

        /// <summary>
        /// 当PageCount等于1时 图片的originalImageUrl存在这里
        /// </summary>
        [JsonPropertyName("meta_single_page")]
        public MetaSinglePageEntity MetaSinglePage { get; set; } = default!;

        /// <summary>
        /// 当PageCount大于1时 图片的ImageUrlsEntity存在这里
        /// </summary>
        [JsonPropertyName("meta_pages")]
        public List<MetaPageEntity> MetaPages { get; set; } = default!;

        [JsonPropertyName("total_view")]
        public int TotalView { get; set; }

        [JsonPropertyName("is_bookmarked")]
        public bool IsBookmarked { get; set; }

        [JsonPropertyName("visible")]
        public bool Visible { get; set; }

        [JsonPropertyName("is_muted")]
        public bool IsMuted { get; set; }

        /// <summary>
        /// 这个字段必须在获取 "detail" 的时候才有值
        /// </summary>
        [JsonPropertyName("total_comments")]
        public int? TotalComments { get; set; }
    }
}
