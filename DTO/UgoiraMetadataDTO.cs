using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class UgoiraMetadataDTO
    {
        [JsonPropertyName("ugoira_metadata")]
        public UgoiraMetadataContentData UgoiraMetadata { get; set; } = default!;

        public sealed class UgoiraMetadataContentData
        {
            [JsonPropertyName("zipUrls")]
            public ZipUrlsData ZipUrls { get; set; } = default!;

            [JsonPropertyName("frames")]
            public List<FrameData> Frames { get; set; } = default!;

            public sealed class ZipUrlsData
            {
                [JsonPropertyName("medium")]
                public string Medium { get; set; } = default!;

            }

            public sealed class FrameData
            {
                [JsonPropertyName("file")]
                public string File { get; set; } = default!;

                [JsonPropertyName("delay")]
                public int Delay { get; set; }
            }
        }
    }
}
