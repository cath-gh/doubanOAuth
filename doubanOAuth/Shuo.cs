using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 广播信息
    /// </summary>
    public class ShuoInfo
    {
        [JsonProperty("category")]
        public string Category { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("user")]
        public ShuoUser User { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("text")]
        public string Text { get; private set; }
        [JsonProperty("attachments")]
        public List<ShuoAttachments> Attachments { get; private set; }
        //[JsonProperty("entities")]
        //public string Entities { get; private set; }
        [JsonProperty("source")]
        public ShuoSource Source { get; private set; }
        [JsonProperty("muted")]
        public string Muted { get; private set; }
        [JsonProperty("reshared_count")]
        public int ResharedCount { get; private set; }
        [JsonProperty("like_count")]
        public int LikeCount { get; private set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; }
        [JsonProperty("can_reply")]
        public bool CanReply { get; private set; }
        [JsonProperty("liked")]
        public bool Liked { get; private set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }
        [JsonProperty("is_follow")]
        public bool IsFollow { get; private set; }
        [JsonProperty("has_photo")]
        public bool HasPhoto { get; private set; }
        [JsonProperty("reshared_status")]
        public ShuoInfo ResharedStatus { get; private set; }
    }

    /// <summary>
    /// 广播信息Pack
    /// </summary>
    public class ShuoInfoPack
    {
        [JsonProperty("status")]
        public ShuoInfo Status { get; private set; }
        [JsonProperty("reshare_users")]
        public List<ShuoUserInfo> ReshareUsers { get; private set; }
        [JsonProperty("like_users")]
        public List<ShuoUserInfo> LikeUsers { get; private set; }
        [JsonProperty("comments")]
        public List<ShuoComment> Comments { get; private set; }
    }

    /// <summary>
    /// 广播用户
    /// </summary>
    public class ShuoUser
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("uid")]
        public string Uid { get; private set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; private set; }
        [JsonProperty("small_avatar")]
        public string SmallAvatar { get; private set; }
        [JsonProperty("large_avatar")]
        public string LargeAvatar { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
    }

    /// <summary>
    /// 广播用户完整版/广播对象
    /// </summary>
    public class ShuoUserInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("uid")]
        public string Uid { get; private set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; private set; }
        [JsonProperty("small_avatar")]
        public string SmallAvatar { get; private set; }
        [JsonProperty("large_avatar")]
        public string LargeAvatar { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("following_count")]
        public int FollowingCount { get; private set; }
        [JsonProperty("blocked")]
        public bool Blocked { get; private set; }
        [JsonProperty("city")]
        public string City { get; private set; }
        [JsonProperty("verified")]
        public bool Verified { get; private set; }
        [JsonProperty("is_first_visit")]
        public bool IsFirstVisit { get; private set; }
        [JsonProperty("new_site_to_vu_count")]
        public int NewSitetoVUCount { get; private set; }
        [JsonProperty("followers_count")]
        public int FollowersCount { get; private set; }
        [JsonProperty("location")]
        public string Location { get; private set; }
        [JsonProperty("logged_in")]
        public bool LoggedIn { get; private set; }
        [JsonProperty("icon_avatar")]
        public string IconAvatar { get; private set; }
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; private set; }
        [JsonProperty("blocking")]
        public bool Blocking { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }
        [JsonProperty("following")]
        public bool Following { get; private set; }

        [JsonProperty("utags")]
        public List<ShuoRTags> UTags { get; private set; }
        [JsonProperty("flag_icon")]
        public string FlagIcon { get; private set; }
        [JsonProperty("agents")]
        public List<string> Agents { get; private set; }
        [JsonProperty("show_agent")]
        public bool ShowAgent { get; private set; }
        [JsonProperty("original_site_id")]
        public string OriginalSiteId { get; private set; }
        [JsonProperty("original_site_url")]
        public string OriginalSiteUrl { get; private set; }
        [JsonProperty("original_tribe_id")]
        public string OriginalTribeId { get; private set; }
        [JsonProperty("original_tribe_url")]
        public string OriginalTribeUrl { get; private set; }
    }

    /// <summary>
    /// 用户关系标签
    /// </summary>
    public class ShuoRTags
    {
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
    }

    /// <summary>
    /// 广播评论
    /// </summary>
    public class ShuoComment
    {
        //[JsonProperty("entities")]
        //public string Entities { get; private set; }
        [JsonProperty("text")]
        public string Text { get; private set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; private set; }
        [JsonProperty("source")]
        public string Source { get; private set; }
        [JsonProperty("user")]
        public ShuoUserInfo User { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
    }

    /// <summary>
    /// 广播项
    /// </summary>
    public class ShuoAttachments
    {
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("href")]
        public string Href { get; private set; }
        [JsonProperty("expaned_href")]
        public string ExpanedHref { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("media")]
        public List<ShuoMedia> Media { get; private set; }
        [JsonProperty("caption")]
        public string Caption { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }
        //[JsonProperty("properties")]
        //public string Properties { get; private set; }
    }

    /// <summary>
    /// 应用信息
    /// </summary>
    public class ShuoSource
    {
        [JsonProperty("source")]
        public string Href { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
    }

    /// <summary>
    /// 广播媒体
    /// </summary>
    public class ShuoMedia
    {
        [JsonProperty("src")]
        public string Src { get; private set; }
        [JsonProperty("href")]
        public string Href { get; private set; }
        [JsonProperty("secret_pid")]
        public string SecretPid { get; private set; }
        [JsonProperty("original_src")]
        public string OriginalSrc { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("artist")]
        public string Artist { get; private set; }
        [JsonProperty("album")]
        public string Album { get; private set; }
        [JsonProperty("sizes")]
        public ShuoSizes Sizes { get; private set; }
        [JsonProperty("type")]
        public string Type { get; private set; }
    }

    /// <summary>
    /// 图片尺寸
    /// </summary>
    public class ShuoSizes
    {
        [JsonProperty("small")]
        public List<int> Small { get; private set; }
        [JsonProperty("median")]
        public List<int> Median { get; private set; }
        [JsonProperty("raw")]
        public List<int> Raw { get; private set; }
    }

    /// <summary>
    /// 用户间关系
    /// </summary>
    public class ShuoFriendship
    {
        [JsonProperty("source")]
        public ShuoFollowInfo Source { get; private set; }
        [JsonProperty("target")]
        public ShuoFollowInfo Target { get; private set; }
    }

    /// <summary>
    /// Follow信息
    /// </summary>
    public class ShuoFollowInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("screen_name")]
        public string ScreenName { get; private set; }
        [JsonProperty("following")]
        public bool Following { get; private set; }
        [JsonProperty("followed_by")]
        public bool FollowedBy { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 发送一条广播(发图待测试)
        /// </summary>
        /// <param name="text">广播文本内容</param>
        /// <param name="recTitle">(可选)推荐网址的标题</param>
        /// <param name="recUrl">(可选)推荐网址的href</param>
        /// <param name="recDesc">(可选)推荐网址的描述</param>
        /// <param name="rec_image">(可选)推荐网址的附图url</param>
        /// <param name="image">(可选)我说的图(有image的情况下rec系列参数都会被忽略)</param>
        /// <returns>广播信息</returns>
        public static ShuoInfo ShuoPostShuo(string text, string recTitle = null, string recUrl = null, string recDesc = null, string recImage = null, object image = null)
        {
            string url = Utilities.CreateUrl(Common.SHUOPOST);
            StringBuilder builder = new StringBuilder();
            builder.Append("text", text);
            builder.Append("rec_title", recTitle);
            builder.Append("rec_url", recUrl);
            builder.Append("rec_desc", recDesc);
            builder.Append("rec_image", recImage);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (ShuoInfo)Utilities.JsonDeserialize<ShuoInfo>(result);
        }

        /// <summary>
        /// 获取友邻广播
        /// </summary>
        /// <param name="sinceId">(可选)起始广播id</param>
        /// <param name="untilId">(可选)结束广播id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播信息列表</returns>
        public static List<ShuoInfo> ShuoGetHomeShuos(Int64? sinceId = null, Int64? untilId = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOHOMESHUOS);
            Utilities.AddParam(ref ub, "since_id", sinceId);
            Utilities.AddParam(ref ub, "until_id", untilId);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (List<ShuoInfo>)Utilities.JsonDeserialize<List<ShuoInfo>>(result);
        }

        /// <summary>
        /// 获取用户广播
        /// </summary>
        /// <param name="sinceId">(可选)起始广播id</param>
        /// <param name="untilId">(可选)结束广播id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播信息列表</returns>
        public static List<ShuoInfo> ShuoGetUserShuos(string id, Int64? sinceId = null, Int64? untilId = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOUSERSHUOS_ID, id);
            Utilities.AddParam(ref ub, "since_id", sinceId);
            Utilities.AddParam(ref ub, "until_id", untilId);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoInfo>)Utilities.JsonDeserialize<List<ShuoInfo>>(result);
        }

        /// <summary>
        /// 读取一条广播
        /// </summary>
        /// <param name="id">广播id</param>
        /// <returns>广播信息</returns>
        public static ShuoInfo ShuoGetShuo(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.SHUOOP_ID, id));
            return (ShuoInfo)Utilities.JsonDeserialize<ShuoInfo>(result);
        }

        /// <summary>
        /// 读取一条广播
        /// </summary>
        /// <param name="id">广播id</param>
        /// <returns>广播信息Pack</returns>
        public static ShuoInfoPack ShuoGetInfoPack(string id)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOOP_ID, id);
            Utilities.AddParam(ref ub, "pack", true);
            string result = Utilities.RequestGet(ub.ToString());
            return (ShuoInfoPack)Utilities.JsonDeserialize<ShuoInfoPack>(result);
        }

        /// <summary>
        /// 删除一条广播
        /// </summary>
        /// <param name="id">广播id</param>
        public static void ShuoDeleteShuo(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.SHUOOP_ID, id));
        }

        /// <summary>
        /// 发表一条评论
        /// </summary>
        /// <param name="id">广播id</param>
        /// <param name="text">评论文本</param>
        /// <returns>广播评论</returns>
        public static ShuoComment ShuoPostComment(string id, string text)
        {
            string url = Utilities.CreateUrl(Common.SHUOCOMMENTSOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("text", text);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (ShuoComment)Utilities.JsonDeserialize<ShuoComment>(result);
        }

        /// <summary>
        /// 获取一条广播的回复列表
        /// </summary>
        /// <param name="id">广播id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>评论列表</returns>
        public static List<ShuoComment> ShuoGetComments(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOCOMMENTSOP_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoComment>)Utilities.JsonDeserialize<List<ShuoComment>>(result);
        }

        /// <summary>
        /// 获取单条回复
        /// </summary>
        /// <param name="id">评论id</param>
        /// <returns>广播评论</returns>
        public static ShuoComment ShuoGetComment(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.SHUOCOMMENTOP_ID, id));
            return (ShuoComment)Utilities.JsonDeserialize<ShuoComment>(result);
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="id">评论id</param>
        public static void ShuoDeleteComment(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.SHUOCOMMENTOP_ID, id));
        }

        /// <summary>
        /// 获取转播用户
        /// </summary>
        /// <param name="id">广播id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetReshareUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUORESHAREOP_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 转播
        /// </summary>
        /// <param name="id">广播id</param>
        /// <returns>广播信息</returns>
        public static ShuoInfo ShuoPostReshare(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.SHUORESHAREOP_ID, id));
            return (ShuoInfo)Utilities.JsonDeserialize<ShuoInfo>(result);
        }

        /// <summary>
        /// 获取赞用户
        /// </summary>
        /// <param name="id">广播id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetLikeUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOLIKEOP_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 赞
        /// </summary>
        /// <param name="id">广播id</param>
        /// <returns>广播信息</returns>
        public static ShuoInfo ShuoPostLike(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.SHUOLIKEOP_ID, id));
            return (ShuoInfo)Utilities.JsonDeserialize<ShuoInfo>(result);
        }

        /// <summary>
        /// 取消赞
        /// </summary>
        /// <param name="id">广播id</param>
        public static void ShuoDeleteLike(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.SHUOLIKEOP_ID, id));
        }

        /// <summary>
        /// 获取用户关注列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="tag">(可选)用户关系标签id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetUserFollows(string id, string tag = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOUSERFOLLOWS_ID, id);
            Utilities.AddParam(ref ub, "tag", tag);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 获取用户关注者列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetFollowUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOFOLLOWUSERS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 获取共同关注的用户列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetFollowinCommons(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOFOLLOWINCOMMONS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 获取关注的人关注了该用户的列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoGetUserinFollows(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOUSERINFOLLOWS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 搜索广播用户
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>广播用户列表</returns>
        public static List<ShuoUserInfo> ShuoSearchUsers(string keyword, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOSEARCHUSERS);
            Utilities.AddParam(ref ub, "q", keyword);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (List<ShuoUserInfo>)Utilities.JsonDeserialize<List<ShuoUserInfo>>(result);
        }

        /// <summary>
        /// 将指定用户加入黑名单
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="userId">用户id</param>
        public static void ShuoPostBlock(string id, string userId)
        {
            string url = Utilities.CreateUrl(Common.SHUOBLOCKUSER_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("user_id", userId);
            string result = Utilities.RequestPost(url, builder.ToString());
        }

        /// <summary>
        /// 建立关注
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>广播用户</returns>
        public static ShuoUserInfo ShuoPostFollow(string id)
        {
            string url = Utilities.CreateUrl(Common.SHUOPOSTFOLLOW);
            StringBuilder builder = new StringBuilder();
            builder.Append("user_id", id);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (ShuoUserInfo)Utilities.JsonDeserialize<ShuoUserInfo>(result);
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>广播用户</returns>
        public static ShuoUserInfo ShuoDeleteFollow(string id)
        {
            string url = Utilities.CreateUrl(Common.SHUODELETEFOLLOW);
            StringBuilder builder = new StringBuilder();
            builder.Append("user_id", id);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (ShuoUserInfo)Utilities.JsonDeserialize<ShuoUserInfo>(result);
        }

        /// <summary>
        /// 获取两个用户的关系
        /// </summary>
        /// <param name="sourceId">源用户id</param>
        /// <param name="targetId">目的用户id</param>
        /// <returns>用户间关系</returns>
        public static ShuoFriendship ShuoGetFriendship(string sourceId, string targetId)
        {
            UriBuilder ub = Utilities.CreateUB(Common.SHUOFRIENDSHIP);
            Utilities.AddParam(ref ub, "source_id", sourceId);
            Utilities.AddParam(ref ub, "target_id", targetId);
            string result = Utilities.RequestGet(ub.ToString());
            return (ShuoFriendship)Utilities.JsonDeserialize<ShuoFriendship>(result);
        }
    }
}
