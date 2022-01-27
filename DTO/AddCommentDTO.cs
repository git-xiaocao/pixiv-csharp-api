using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class AddCommentDTO
    {
        [JsonPropertyName("comment")]
        public CommentEntity Comment { get; set; } = default!;
    }
}
