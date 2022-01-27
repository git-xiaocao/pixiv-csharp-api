using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class ProfileImageUrlsEntity
    {
        [JsonPropertyName("medium")]
        public string Medium { get; set; } = default!;

    }
}
