using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class NovelJSDataDTO
    {
        /// <summary>
        /// string
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// string
        /// </summary>
        [JsonPropertyName("seriesId")]
        public int SeriesId { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("coverUrl")]
        public string CoverUrl { get; set; } = default!;

        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;

        [JsonPropertyName("seriesNavigation")]
        public SeriesNavigationData? SeriesNavigation { get; set; } = default!;

        public sealed class SeriesNavigationData
        {
            [JsonPropertyName("nextNovel")]
            public TurnPageNovelData? NextNovel { get; set; }

            [JsonPropertyName("prevNovel")]
            public TurnPageNovelData? PrevNovel { get; set; }

            public sealed class TurnPageNovelData
            {
                [JsonPropertyName("id")]
                public int Id { get; set; }

                [JsonPropertyName("viewable")]
                public bool Viewable { get; set; }

                /// <summary>
                /// string
                /// 页码
                /// </summary>
                [JsonPropertyName("contentOrder")]
                public int ContentOrder { get; set; }

                [JsonPropertyName("title")]
                public string Title { get; set; } = default!;

                [JsonPropertyName("coverUrl")]
                public string CoverUrl { get; set; } = default!;

            }
        }
    }
}
