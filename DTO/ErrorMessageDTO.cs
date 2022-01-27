using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class ErrorMessageDTO
    {
        [JsonPropertyName("error")]
        public ErrorData Error { get; set; } = default!;

        public class ErrorData
        {
            [JsonPropertyName("user_message")]
            public string? UserMessage { get; set; }

            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("reason")]
            public string? Reason { get; set; }

            [JsonPropertyName("user_message_details")]
            public object? UserMessageDetails { get; set; }
        }
    }
}
