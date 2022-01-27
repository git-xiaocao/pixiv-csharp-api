using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PixivAPI
{
    public static class Json
    {
        private static readonly JsonSerializerOptions options = new() { };

        public static T Decode<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, options)!;
        }

        public static T Decode<T>(byte[] jsonBytes)
        {
            return JsonSerializer.Deserialize<T>(jsonBytes, options)!;
        }
            
        public static string Encode<T>(T jsonObject)
        {
            return JsonSerializer.Serialize<T>(jsonObject, options);
        }
    }
}
