using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PixivAPI
{
    public static class Utils
    {
        public static string GenerateCodeChallenge(string s)
        {
            return Base64UrlEncode(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(s)));
        }

        public static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                .Replace("=", "")
                .Replace("/", "_")
                .Replace("+", "-");
        }

        public static string RandomString(int length)
        {
            const string randomKeySet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~";
            return new string(Enumerable.Repeat(randomKeySet, length).Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// 生成登录Url
        /// <code>string codeVerifier = RandomString(128);</code>
        /// <code>string codeChallenge = GenerateCodeChallenge(codeVerifier);</code>
        /// </summary>
        /// <param name="isCreate">是否为注册</param>
        /// <returns></returns>
        public static string GenerateLoginUrl(string codeChallenge, bool isCreate)
        {
            string baseUrl = "https://app-api.pixiv.net/web/v1";
            return $"{baseUrl}{(isCreate ? "/provisional-accounts/create" : "/login")}?code_challenge={codeChallenge}&code_challenge_method=S256&client=pixiv-android";
        }
    }
}
