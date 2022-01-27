using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.Entity
{
    public sealed class LocalUserEntity
    {
        [JsonPropertyName("profile_image_urls")]
        public LoclaUserProfileImageUrlsEntity ProfileImageUrls { get; set; } = default!;

        [JsonPropertyName("id")]
        public string Id { get; set; }=default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("account")]
        public string Account { get; set; }=default!;

        [JsonPropertyName("mail_address")]
        public string MailAddress { get; set; } = default!;

        [JsonPropertyName("is_premium")]
        public bool IsPremium { get; set; }

        [JsonPropertyName("x_restrict")]
        public int XRestrict { get; set; }

        [JsonPropertyName("is_mail_authorized")]
        public bool IsMailAuthorized { get; set; }

        [JsonPropertyName("require_policy_agreement")]
        public bool RequirePolicyAgreement { get; set; }


        public sealed class LoclaUserProfileImageUrlsEntity
        {
            [JsonPropertyName("px_16x16")]
            public string Px16x16 { get; set; } = default!;

            [JsonPropertyName("px_50x50")]
            public string Px50x50 { get; set; } = default!;

            [JsonPropertyName("px_170x170")]
            public string Px170x170 { get; set; } = default!;
        }

    }
}
