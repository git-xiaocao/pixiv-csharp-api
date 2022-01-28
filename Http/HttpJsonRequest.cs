using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.Http
{
    internal class HttpJsonRequest<T> : HttpBytesRequest
    {

        public HttpJsonRequest(HttpClient client, CancellationToken? cancellationToken) : base(client, cancellationToken)
        {

        }

        public static Task<T> operator +(HttpJsonRequest<T> thisObject) => thisObject.SendAsync();

        public async new Task<T> SendAsync()
        {
            return Json.Decode<T>(await base.SendAsync());
        }
    }

}
