using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PixivAPI.Http
{
    internal class HttpBytesRequest
    {
        private readonly HttpClient client;
        private readonly NameValueCollection query;
        private readonly CancellationToken? cancellationToken;

        public HttpBytesRequest(HttpClient client, CancellationToken? cancellationToken)
        {
            this.client = client;
            query = HttpUtility.ParseQueryString(string.Empty);
            this.cancellationToken = cancellationToken;
        }

        public string UriString { get; set; } = default!;

        public HttpMethod Method { get; set; } = HttpMethod.Get;

        public HttpContent? Content { get; set; }
        public object? this[string name]
        {
            set
            {
                if (value is string @string)
                {
                    query[name] = @string;
                }
                else if (value is int @int)
                {
                    query[name] = @int.ToString();
                }
                else if (value is bool @bool)
                {
                    query[name] = @bool ? "true" : "false";
                }
                else
                {
                    throw new ArgumentException("查询参数只能是string int bool类型");
                }
            }

        }

        public string this[bool val] { set { query[value] = val ? "true" : "false"; } }

        public string this[int val] { set { query[value] = val.ToString(); } }

        public static Task<byte[]> operator +(HttpBytesRequest thisObject) => thisObject.SendAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpException"></exception>
        public async Task<byte[]> SendAsync()
        {
            HttpRequestMessage request = new(Method, new UriBuilder(client.BaseAddress is not null ? new Uri(client.BaseAddress, UriString) : new Uri(UriString))
            {
                Query = query.ToString(),
            }.ToString());
            request.Content = Content;

            HttpResponseMessage response;
            if (cancellationToken is CancellationToken token)
                response = await client.SendAsync(request, token);
            else
                response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new HttpException(request, response);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
