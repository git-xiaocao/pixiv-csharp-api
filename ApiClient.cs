using PixivAPI.DTO;
using PixivAPI.Entity;
using PixivAPI.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PixivAPI
{
    public class ApiClient
    {
        private const string TARGET_IP = "210.140.92.183";
        private const string TARGET_HOST = "app-api.pixiv.net";

        private readonly HttpClient client;

        public ApiClient(AuthClient authClient, StringWithQualityHeaderValue language)
        {
            client = new HttpClient(new ClientHandler(authClient, TARGET_IP))
            {
                BaseAddress = new Uri($"https://{TARGET_IP}")
            };

            client.DefaultRequestHeaders.AcceptLanguage.Add(language);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("PixivAndroidApp/6.21.1 (Android 10.0.0; XiaoCao)");
            client.DefaultRequestHeaders.Host = TARGET_HOST;
            client.DefaultRequestHeaders.Add("App-OS", "Android");
            client.DefaultRequestHeaders.Add("App-OS-Version", "10.0.0");
            client.DefaultRequestHeaders.Add("App-Version", "6.2.1");
        }

        public async Task<T> Next<T>(string url) where T : IPixivListData
        {
            return Json.Decode<T>(await client.GetByteArrayAsync(url.Replace(TARGET_HOST, TARGET_IP)));
        }

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>

        /// <returns>
        /// 用户详细信息 <see cref="UserDetailDTO"/>
        /// </returns>
        public Task<UserDetailDTO> GetUserDetail(int userId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<UserDetailDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/detail",

                ["filter"] = "for_android",
                ["user_id"] = userId
            };
        }

        /// <summary>
        /// 获取用户收藏的插画
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="restrict"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetUserIllustBookmarks(int userId, Restrict restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/bookmarks/illust",

                ["user_id"] = userId,
                ["restrict"] = restrict.ToPixivStringParameter()
            };
        }

        /// <summary>
        /// 获取用户收藏的小说
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="restrict"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<NovelsDTO> GetUserNovelBookmarks(int userId, Restrict restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<NovelsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/bookmarks/novel",

                ["user_id"] = userId,
                ["restrict"] = restrict.ToPixivStringParameter()
            };
        }

        /// <summary>
        /// 获取用户的插画
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="type">获取的类型</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetUserIllusts(int userId, IllustType type, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/illusts",

                ["filter"] = "for_android",
                ["user_id"] = userId,
                ["type"] = type.ToPixivStringParameter(),
            };
        }

        /// <summary>
        /// 获取用户的小说
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<NovelsDTO> GetUserNovels(int userId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<NovelsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/novels",

                ["user_id"] = userId,
            };
        }

        /// <summary>
        /// 获取推荐插画
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetRecommendedIllusts(IllustType type, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = $"/v1/{type.ToPixivStringParameter()}/recommended",

                ["filter"] = "for_android",
            };
        }

        /// <summary>
        /// 获取推荐插画
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<NovelsDTO> GetRecommendedNovels(CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<NovelsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/novel/recommended",

                ["include_ranking_novels"] = false,
                ["include_privacy_policy"] = false,
            };
        }

        /// <summary>
        /// 获取排行榜
        /// </summary>
        /// <param name="mode">模式</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetRanking(RankingMode mode, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/illusts/ranking",

                ["filter"] = "for_android",
                ["mode"] = mode.ToPixivStringParameter(),
            };
        }


        /// <summary>
        /// 获取推荐标签(搜索用的)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 标签数据列表(无Next) <see cref="TrendingTagsDTO"/>
        /// </returns>
        public Task<TrendingTagsDTO> GetTrendingTags(CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<TrendingTagsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/trending-tags/illust",

                ["filter"] = "for_android",
            };
        }


        /// <summary>
        /// 获取推荐用户
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 用户列表 <see cref="UsersDTO"/>
        /// </returns>
        public Task<UsersDTO> GetRecommendedUsers(CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<UsersDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/recommended",

                ["filter"] = "for_android",
            };
        }

        /// <summary>
        /// 获取关注用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="restrict"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 用户列表 <see cref="UsersDTO"/>
        /// </returns>
        public Task<UsersDTO> GetFollowingUsers(int userId, Restrict restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<UsersDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/user/following",

                ["filter"] = "for_android",
                ["user_id"] = userId,
                ["restrict"] = restrict.ToPixivStringParameter(),
            };
        }

        /// <summary>
        /// 获取关注者的新插画
        /// </summary>
        /// <param name="restrict">null(全部)</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetFollowerNewIllusts(Restrict? restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/illust/follow",

                ["filter"] = "for_android",
                ["restrict"] = restrict is null ? "all" : restrict.ToPixivStringParameter(),
            };
        }

        /// <summary>
        /// 获取关注者的新小说
        /// </summary>
        /// <param name="restrict">null(全部)</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<NovelsDTO> GetFollowerNewNovels(Restrict? restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<NovelsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/novel/follow",

                ["filter"] = "for_android",
                ["restrict"] = restrict is null ? "all" : restrict.ToPixivStringParameter(),
            };
        }

        /// <summary>
        /// 获取最近发布的插画
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetNewIllusts(IllustType type, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/illust/new",

                ["filter"] = "for_android",
                ["content_type"] = type.ToPixivStringParameter(),
            };
        }

        /// <summary>
        /// 获取最近发布的小说
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="NovelsDTO"/>
        /// </returns>
        public Task<NovelsDTO> GetNewNovels(CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<NovelsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/novel/new",
            };
        }

        /// <summary>
        /// 获取插画的相关推荐
        /// </summary>
        /// <param name="illustId">插画ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustsDTO> GetIllustRelated(int illustId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v2/illust/related",

                ["filter"] = "for_android",
                ["illust_id"] = illustId,
            };
        }

        /// <summary>
        /// 获取插画详细
        /// </summary>
        /// <param name="illustId">插画ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画详细信息 <see cref="IllustsDTO"/>
        /// </returns>
        public Task<IllustDetailDTO> GetIllustDetail(int illustId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<IllustDetailDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/illust/detail",

                ["filter"] = "for_android",
                ["illust_id"] = illustId,
            };
        }


        /// <summary>
        /// 获取小说HTML页面
        /// </summary>
        /// <param name="novelId">小说ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说HTML页面字符串 <see cref="string"/>
        /// </returns>
        public Task<string> GetNovelHtml(int novelId, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/webview/v1/novel",

                ["id"] = novelId,
            };
        }

        /// <summary>
        /// 获取动图
        /// </summary>
        /// <param name="illustId">插画ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 动图元数据 <see cref="UgoiraMetadataDTO"/>
        /// </returns>
        public Task<UgoiraMetadataDTO> GetUgoiraMetadata(int illustId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<UgoiraMetadataDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/ugoira/metadata",

                ["illust_id"] = illustId,
            };
        }

        /// <summary>
        /// 获取评论的回复
        /// </summary>
        /// <param name="commentId">评论ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 回复列表 <see cref="UgoiraMetadataDTO"/>
        /// </returns>
        public Task<CommentsDTO> GetCommentReplies(int commentId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<CommentsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v2/illust/comment/replies",

                ["comment_id"] = commentId,
            };
        }


        /// <summary>
        /// 获取插画的评论
        /// </summary>
        /// <param name="illustId">插画ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 回复列表 <see cref="UgoiraMetadataDTO"/>
        /// </returns>
        public Task<CommentsDTO> GetIllustComments(int illustId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<CommentsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v3/illust/comments",

                ["illust_id"] = illustId,
            };
        }

        /// <summary>
        /// 搜索的关键字自动补全
        /// </summary>
        /// <param name="word">关键字</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 自动补全列表(没有Next) <see cref="SearchAutocompleteDTO"/>
        /// </returns>
        public Task<SearchAutocompleteDTO> SearchAutocomplete(int word, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<SearchAutocompleteDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v2/search/autocomplete",

                ["merge_plain_keyword_results"] = true,
                ["word"] = word,

            };
        }

        /// <summary>
        /// 搜索插画
        /// </summary>
        /// <param name="word">关键字</param>
        /// <param name="sort">排序</param>
        /// <param name="target">搜索目标</param>
        /// <param name="startDate">开始时间(必须跟endDate一起填)</param>
        /// <param name="endDate">结束时间(必须跟startDate一起填)</param>
        /// <param name="bookmarkTotal">收藏数量 100, 250, 500, 1000, 5000, 7500 , 10000, 20000, 30000, 50000</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 插画列表 <see cref="SearchIllustDTO"/>
        /// </returns>
        public Task<SearchIllustDTO> SearchIllust(
            int word, SearchSort sort, SearchTarget target, DateTime? startDate, DateTime? endDate, int? bookmarkTotal, CancellationToken? cancellationToken = null
        )
        {
            return +new HttpJsonRequest<SearchIllustDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/search/illust",

                ["filter"] = "for_android",
                ["include_translated_tag_results"] = true,
                ["merge_plain_keyword_results"] = true,
                ["word"] = bookmarkTotal is null ? word : $"{word} {bookmarkTotal}users入り",
                ["sort"] = sort.ToPixivStringParameter(),
                ["search_target"] = target.ToPixivStringParameter(),
                ["start_date"] = startDate?.ToString("yyyy-MM-dd"),
                ["end_date"] = endDate?.ToString("yyyy-MM-dd"),
            };
        }

        /// <summary>
        /// 搜索小说
        /// </summary>
        /// <param name="word">关键字</param>
        /// <param name="sort">排序</param>
        /// <param name="target">搜索目标</param>
        /// <param name="startDate">开始时间(必须跟endDate一起填)</param>
        /// <param name="endDate">结束时间(必须跟startDate一起填)</param>
        /// <param name="bookmarkTotal">收藏数量 100, 250, 500, 1000, 5000, 7500 , 10000, 20000, 30000, 50000</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 小说列表 <see cref="SearchNovelDTO"/>
        /// </returns>
        public Task<SearchNovelDTO> SearchNovel(
            int word, SearchSort sort, SearchTarget target, DateTime? startDate, DateTime? endDate, int? bookmarkTotal, CancellationToken? cancellationToken = null
        )
        {
            return +new HttpJsonRequest<SearchNovelDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/search/novel",

                ["include_translated_tag_results"] = true,
                ["merge_plain_keyword_results"] = true,
                ["word"] = bookmarkTotal is null ? word : $"{word} {bookmarkTotal}users入り",
                ["sort"] = sort.ToPixivStringParameter(),
                ["search_target"] = target.ToPixivStringParameter(),
                ["start_date"] = startDate?.ToString("yyyy-MM-dd"),
                ["end_date"] = endDate?.ToString("yyyy-MM-dd"),
            };
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="word">关键字</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 用户列表 <see cref="UsersDTO"/>
        /// </returns>
        public Task<UsersDTO> SearchUsers(string word, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<UsersDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = "/v1/search/user",

                ["filter"] = "for_android",
                ["word"] = word,

            };
        }

        /// <summary>
        /// 获取收藏标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="restrict"></param>
        /// <param name="isNovel">是否为小说</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 收藏的标签数组 <see cref="BookmarkTagsDTO"/>
        /// </returns>
        public Task<BookmarkTagsDTO> GetBookmarkTags(int userId, Restrict restrict, bool isNovel, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<BookmarkTagsDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Get,
                UriString = $"/v1/user/bookmark-tags/{(isNovel ? "novel" : "illust")}",

                ["user_id"] = userId,
                ["restrict"] = restrict.ToPixivStringParameter(),

            };
        }

        /// <summary>
        /// 收藏作品
        /// </summary>
        /// <param name="id">作品ID</param>
        /// <param name="tags">作品ID</param>
        /// <param name="restrict"></param>
        /// <param name="isNovel">是否为小说</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 没有 <see cref="string"/>
        /// </returns>
        public Task<string> AddBookmark(int id, List<string> tags, Restrict restrict, bool isNovel, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = $"/v1/{(isNovel ? "novel" : "illust")}/comment/delete",

                Content = new FormData()
                {
                    [$"{(isNovel ? "novel" : "illust")}_id"] = id,
                    ["restrict"] = restrict.ToPixivStringParameter(),
                    ["tags"] = Json.Encode(tags)
                }
            };
        }

        /// <summary>
        /// 取消收藏作品
        /// </summary>
        /// <param name="id">作品ID</param>
        /// <param name="isNovel">是否为小说</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 没有 <see cref="string"/>
        /// </returns>
        public Task<string> DeleteBookmark(int id, bool isNovel, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = $"/v1/${(isNovel ? "novel" : "illust")}/bookmark/delete",

                Content = new FormData()
                {
                    [$"{(isNovel ? "novel" : "illust")}_id"] = id,

                }
            };
        }

        /// <summary>
        /// 关注用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="restrict"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 没有 <see cref="string"/>
        /// </returns>
        public Task<string> AddFollow(int userId, Restrict restrict, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = $"/v1/user/follow/add",

                Content = new FormData()
                {
                    ["user_id"] = userId,
                    ["restrict"] = restrict.ToPixivStringParameter(),
                }
            };
        }

        /// <summary>
        /// 取消关注用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 没有 <see cref="string"/>
        /// </returns>
        public Task<string> DeleteFollow(int userId, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = $"/v1/user/follow/delete",

                Content = new FormData()
                {
                    ["user_id"] = userId,
                }
            };
        }

        /// <summary>
        /// 添加评论(评论一个插画)
        /// </summary>
        /// <param name="illustId">插画ID</param>
        /// <param name="comment">评论内容</param>
        /// <param name="stampId">表情包ID</param>
        /// <param name="parentCommentId">父评论ID(用来回复)</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 添加的评论 <see cref="AddCommentDTO"/>
        /// </returns>
        public Task<AddCommentDTO> AddComment(int illustId, string comment, int? stampId, int? parentCommentId, CancellationToken? cancellationToken = null)
        {
            return +new HttpJsonRequest<AddCommentDTO>(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = "/v1/illust/comment/add",

                Content = new FormData()
                {
                    ["illust_id"] = illustId,
                    ["comment"] = comment,
                    ["stamp_id"] = stampId,
                    ["parent_comment_id"] = parentCommentId,
                }
            };
        }

        /// <summary>
        /// 删除评论(自己的)
        /// </summary>
        /// <param name="commentId">插画ID</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="HttpException"/>
        /// <returns>
        /// 没有 <see cref="string"/>
        /// </returns>
        public Task<string> DeleteComment(int commentId, CancellationToken? cancellationToken = null)
        {
            return +new HttpStringRequest(client, cancellationToken)
            {
                Method = HttpMethod.Post,
                UriString = $"/v1/illust/comment/delete",

                Content = new FormData()
                {
                    ["comment_id"] = commentId,
                }
            };
        }


        internal class ClientHandler : CustomIpHttpsHandler
        {
            private readonly AuthClient authClient;

            private readonly Mutex refreshTokenMutex = new();


            public ClientHandler(AuthClient authClient, string targetIp) : base(targetIp)
            {
                this.authClient = authClient;
            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Authorization = new("Bearer", authClient.AccessToken);
                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                if (HttpStatusCode.BadRequest == response.StatusCode)
                {
                    if (response.Content.ReadAsStringAsync(cancellationToken).Result.Contains("OAuth"))
                    {
                        refreshTokenMutex.WaitOne();
                        for (int retryCount = 0; retryCount < 3; ++retryCount)
                        {
                            request.Headers.Authorization = new("Bearer", (await authClient.RefreshAuthTokenAsync()).AccessToken);
                            response = await base.SendAsync(request, cancellationToken);

                            if (response.IsSuccessStatusCode)
                            {
                                refreshTokenMutex.ReleaseMutex();
                                return response;
                            }
                        }
                        refreshTokenMutex.ReleaseMutex();
                    }

                }

                return response;
            }
        }
    }

}
