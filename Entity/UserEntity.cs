using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class UserEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("profile_image_urls")]
        public ProfileImageUrlsEntity ProfileImageUrls { get; set; } = default!;

        /// <summary>
        /// 在CommentEntity中的时候没有这个字段
        /// </summary>
        [JsonPropertyName("is_followed")]
        public bool? IsFollwoed { get; set; }
    }
}
