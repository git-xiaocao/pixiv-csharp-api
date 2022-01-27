using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class StampsDTO
    {
        [JsonPropertyName("stamps")]
        public List<StampEntity> Stamps { get; set; } = default!;

    }
}
