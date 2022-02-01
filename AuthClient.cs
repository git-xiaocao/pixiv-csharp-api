using PixivAPI.DTO;
using PixivAPI.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PixivAPI
{
    public class AuthClient
    {
        private const string TARGET_IP = "210.140.92.183";
        private const string TARGET_HOST = "oauth.secure.pixiv.net";
        private const string HASH_SALT = "28c1fdd170a5204386cb1313c7077b34f83e4aaf4aa829ce78c231e05b0bae2c";
        private const string CLIENT_ID = "MOBrBDS8blbauoSck0ZfDbtuzpyT";
        private const string CLIENT_SECRET = "lsACyCD94FhDUtGTXi3QzcFE2uU1hqtDaKeqrdwj";

        private readonly HttpClient client;

        private readonly Func<UserAccountDTO> getUserAccountFunc;

        private string RefreshToken { get => getUserAccountFunc().RefreshToken; }
        public string AccessToken { get => getUserAccountFunc().AccessToken; }

        public AuthClient(Func<UserAccountDTO> getUserAccountFunc, StringWithQualityHeaderValue language)
        {
            this.getUserAccountFunc = getUserAccountFunc;

            client = new HttpClient(new CustomIpHttpsHandler(TARGET_IP))
            {
                BaseAddress = new Uri($"https://{TARGET_IP}"),
            };

            client.DefaultRequestHeaders.AcceptLanguage.Add(language);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("PixivAndroidApp/6.21.1 (Android 10.0.0; XiaoCao)");
            client.DefaultRequestHeaders.Host = TARGET_HOST;
            client.DefaultRequestHeaders.Add("App-OS", "Android");
            client.DefaultRequestHeaders.Add("App-OS-Version", "10.0.0");
            client.DefaultRequestHeaders.Add("App-Version", "6.2.1");
        }



        /// <summary>
        /// 初始化AuthToken
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeVerifier"></param>
        /// <exception cref="HttpException"/>
        /// <returns></returns>
        public Task<UserAccountDTO> InitAuthToken(string code, string codeVerifier)
        {
            return +new HttpJsonRequest<UserAccountDTO>(client, null)
            {
                Method = HttpMethod.Post,
                UriString = "/auth/token",
                Content = new FormData()
                {
                    ["client_id"] = CLIENT_ID,
                    ["client_secret"] = CLIENT_SECRET,
                    ["include_policy"] = true,
                    ["grant_type"] = "authorization_code",
                    ["code_verifier"] = codeVerifier,
                    ["code"] = code,
                    ["redirect_uri"] = "https://app-api.pixiv.net/web/v1/users/auth/pixiv/callback",
                },
            };
        }

        /// <summary>
        /// 刷新AuthToken
        /// </summary>
        /// <exception cref="HttpException"/>
        /// <returns></returns>
        public Task<UserAccountDTO> RefreshAuthTokenAsync()
        {
            return +new HttpJsonRequest<UserAccountDTO>(client, null)
            {
                Method = HttpMethod.Post,
                UriString = "/auth/token",
                Content = new FormData()
                {
                    ["client_id"] = CLIENT_ID,
                    ["client_secret"] = CLIENT_SECRET,
                    ["include_policy"] = true,
                    ["grant_type"] = "refresh_token",
                    ["refresh_token"] = RefreshToken,
                },
            };

        }

    }
}
