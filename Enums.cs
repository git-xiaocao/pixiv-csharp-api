using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PixivAPI
{
    public enum Restrict
    {
        Public,
        Private,
    }

    public enum RankingMode
    {
        /// <summary>
        /// 天
        /// </summary>
        Day,
        /// <summary>
        /// 天 R18
        /// </summary>
        DayR18,
        /// <summary>
        /// 天 男性欢迎
        /// </summary>
        DayMale,
        /// <summary>
        /// 天 男性欢迎 R18
        /// </summary>
        DayMaleR18,
        /// <summary>
        /// 天 女性欢迎
        /// </summary>
        DayFemale,
        /// <summary>
        /// 天 女性欢迎 R18
        /// </summary>
        DayFemaleR18,
        /// <summary>
        /// 周
        /// </summary>
        Week,
        /// <summary>
        /// 周 R18
        /// </summary>
        WeekR18,
        /// <summary>
        /// 周(原创)
        /// </summary>
        WeekOriginal,
        /// <summary>
        /// 周(新人)
        /// </summary>
        WeekRookie,
        /// <summary>
        /// 月
        /// </summary>
        Month,
    }

    public enum IllustType
    {
        /// <summary>
        /// 插画
        /// </summary>
        Illust,
        /// <summary>
        /// 漫画
        /// </summary>
        Manga,
    }

    public enum WorkType
    {
        /// <summary>
        /// 插画
        /// </summary>
        Illust,
        /// <summary>
        /// 漫画
        /// </summary>
        Manga,
        /// <summary>
        /// 小说
        /// </summary>
        Novel,
    }

    public enum SearchSort
    {
        /// <summary>
        /// 时间降序(最新)
        /// </summary>
        DateDesc,
        /// <summary>
        /// 时间升序(最旧)
        /// </summary>
        DateAsc,
        /// <summary>
        /// 热度降序
        /// </summary>
        PopularDesc,
    }

    public enum SearchTarget
    {
        /// <summary>
        /// 标签(部分匹配)
        /// </summary>
        PartialMatchForTags,
        /// <summary>
        /// 标签(完全匹配)
        /// </summary>
        ExactMatchForTags,
        /// <summary>
        /// 标签&简介
        /// </summary>
        TitleAndCaption,
    }

    internal static class EnumExtensions
    {
        /// <summary>
        /// 枚举类型值转换成Pixiv参数命名格式(小写下划线)
        /// </summary>
        /// <param name="e">枚举类型值</param>
        /// <returns>枚举类型值的小写下划线字符串</returns>
        public static string ToPixivStringParameter(this Enum e)
        {
            return Regex.Replace(e.ToString(), "[A-Z]", (Match match) =>
            {
                return $"_{match.Value}";
            }).ToLower();
        }
    }


}
