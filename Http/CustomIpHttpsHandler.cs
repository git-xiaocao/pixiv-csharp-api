using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI.Http
{
    internal class CustomIpHttpsHandler : HttpMessageHandler
    {
        private readonly HttpMessageInvoker httpMessageInvoker;
        public CustomIpHttpsHandler(string targetIp)
        {
            httpMessageInvoker = new(new SocketsHttpHandler()
            {
                ConnectCallback = async (context, token) =>
                {
                    var sockets = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    await sockets.ConnectAsync(IPAddress.Parse(targetIp), 443, token).ConfigureAwait(false);
                    var networkStream = new NetworkStream(sockets, true);
                    var sslStream = new SslStream(networkStream, false, (_, _, _, _) => true);
                    await sslStream.AuthenticateAsClientAsync(string.Empty).ConfigureAwait(false);
                    return sslStream;
                }
            });
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new(request.RequestUri!.ToString().Replace("https", "http"));
            return httpMessageInvoker.SendAsync(request, cancellationToken);
        }
    }
}
