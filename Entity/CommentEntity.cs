using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class CommentEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; } = default!;

        [JsonPropertyName("date")]
        public string Date { get; set; } = default!;

        [JsonPropertyName("user")]
        public UserEntity User { get; set; } = default!;

        /// <summary>
        /// 有回复
        /// </summary>
        [JsonPropertyName("has_replies")]
        public bool HasReplies { get; set; } = default!;

        /// <summary>
        /// 表情包
        /// </summary>
        [JsonPropertyName("stamp")]
        public string Stamp { get; set; } = default!;
    }
}
