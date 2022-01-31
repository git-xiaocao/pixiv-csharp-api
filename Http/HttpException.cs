using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.Http
{
    internal class HttpException : Exception
    {
        public HttpRequestMessage Request { get; }
        public HttpResponseMessage Response { get; }

        public HttpException(HttpRequestMessage request, HttpResponseMessage response)
        {
            Request = request;
            Response = response;
        }
    }
}
