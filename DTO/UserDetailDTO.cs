using PixivAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PixivAPI.DTO
{
    public sealed class UserDetailDTO
    {
        [JsonPropertyName("user")]
        public UserData User { get; set; } = default!;

        [JsonPropertyName("profile")]
        public UserProfileData Profile { get; set; } = default!;

        [JsonPropertyName("profile_publicity")]
        public UserProfilePublicityData ProfilePublicity { get; set; } = default!;
        
        [JsonPropertyName("workspace")]
        public UserWorkspaceData Workspace { get; set; } = default!;

        public sealed class UserData
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = default!;

            [JsonPropertyName("account")]
            public string Account { get; set; } = default!;

            [JsonPropertyName("profile_image_urls")]
            public ProfileImageUrlsEntity ProfileImageUrls { get; set; } = default!;

            [JsonPropertyName("comment")]
            public string? Comment { get; set; } = default!;

            [JsonPropertyName("is_followed")]
            public bool IsFollowed { get; set; }
        }

        public sealed class UserProfileData
        {
            [JsonPropertyName("webpage")]
            public string? Webpage { get; set; }

            [JsonPropertyName("gender")]
            public string Gender { get; set; } = default!;

            [JsonPropertyName("birth")]
            public string Birth { get; set; } = default!;

            [JsonPropertyName("birth_day")]
            public string BirthDay { get; set; } = default!;

            [JsonPropertyName("birth_year")]
            public int BirthYear { get; set; } = default!;

            [JsonPropertyName("region")]
            public string Region { get; set; } = default!;

            [JsonPropertyName("address_id")]
            public int AddressId { get; set; } = default!;

            [JsonPropertyName("country_code")]
            public string CountryCode { get; set; } = default!;

            [JsonPropertyName("job")]
            public string Job { get; set; } = default!;

            [JsonPropertyName("job_id")]
            public int JobId { get; set; } = default!;

            [JsonPropertyName("total_follow_users")]
            public int TotalFollowUsers { get; set; } = default!;

            [JsonPropertyName("total_mypixiv_users")]
            public int TotalMyPixivUsers { get; set; } = default!;

            [JsonPropertyName("total_illusts")]
            public int TotalIllusts { get; set; } = default!;

            [JsonPropertyName("total_manga")]
            public int TotalManga { get; set; } = default!;

            [JsonPropertyName("total_novels")]
            public int TotalNovels { get; set; } = default!;

            [JsonPropertyName("total_illust_bookmarks_public")]
            public int TotalIllustBookmarksPublic { get; set; } = default!;

            [JsonPropertyName("total_illust_series")]
            public int TotalIllustSeries { get; set; } = default!;

            [JsonPropertyName("total_novel_series")]
            public int TotalNovelSeries { get; set; } = default!;

            [JsonPropertyName("background_image_url")]
            public string? BackgroundImageUrl { get; set; } = default!;

            [JsonPropertyName("twitter_account")]
            public string? TwitterAccount { get; set; } = default!;

            [JsonPropertyName("twitter_url")]
            public string? TwitterUrl { get; set; } = default!;

            [JsonPropertyName("pawoo_url")]
            public string? PawooUrl { get; set; } = default!;

            [JsonPropertyName("is_premium")]
            public bool IsPremium { get; set; } = default!;

            [JsonPropertyName("is_using_custom_profile_image")]
            public bool IsUsingCustomProfileImage { get; set; } = default!;

        }

        public sealed class UserProfilePublicityData
        {
            [JsonPropertyName("gender")]
            public string Gender { get; set; } = default!;

            [JsonPropertyName("region")]
            public string Region { get; set; } = default!;

            [JsonPropertyName("birth_day")]
            public string BirthDay { get; set; } = default!;

            [JsonPropertyName("birth_year")]
            public string BirthYear { get; set; } = default!;

            [JsonPropertyName("job")]
            public string Job { get; set; } = default!;

            [JsonPropertyName("pawoo")]
            public bool Pawoo { get; set; } = default!;
        }

        public sealed class UserWorkspaceData
        {
            [JsonPropertyName("pc")]
            public string PC { get; set; } = default!;

            [JsonPropertyName("monitor")]
            public string Monitor { get; set; } = default!;

            [JsonPropertyName("tool")]
            public string Tool { get; set; } = default!;

            [JsonPropertyName("scanner")]
            public string Scanner { get; set; } = default!;

            [JsonPropertyName("tablet")]
            public string Tablet { get; set; } = default!;

            [JsonPropertyName("mouse")]
            public string Mouse { get; set; } = default!;

            [JsonPropertyName("printer")]
            public string Printer { get; set; } = default!;

            [JsonPropertyName("desktop")]
            public string Desktop { get; set; } = default!;

            [JsonPropertyName("music")]
            public string Music { get; set; } = default!;

            [JsonPropertyName("desk")]
            public string Desk { get; set; } = default!;

            [JsonPropertyName("chair")]
            public string Chair { get; set; } = default!;

            [JsonPropertyName("comment")]
            public string Comment { get; set; } = default!;

            [JsonPropertyName("workspace_image_url")]
            public string? WorkspaceImageUrl { get; set; }
        }
    }
}
