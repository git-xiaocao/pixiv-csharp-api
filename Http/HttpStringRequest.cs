using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.Http
{
    internal class HttpStringRequest : HttpBytesRequest
    {
        public HttpStringRequest(HttpClient client, CancellationToken? cancellationToken) : base(client, cancellationToken)
        {

        }

        public static Task<string> operator +(HttpStringRequest thisObject) => thisObject.SendAsync();

        public async new Task<string> SendAsync()
        {
            return Encoding.Default.GetString(await base.SendAsync());
        }
    }
}
