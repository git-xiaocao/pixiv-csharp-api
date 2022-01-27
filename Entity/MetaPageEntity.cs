using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class MetaPageEntity
    {
        [JsonPropertyName("image_urls")]
        public ImageUrlsEntity ImageUrls { get; set; } = default!;
    }
}
