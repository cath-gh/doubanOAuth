using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 线上活动信息
    /// </summary>
    public class OnlInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("desc")]
        public string Desc { get; private set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("begin_time")]
        public string BeginTime { get; private set; }
        [JsonProperty("end_time")]
        public string EndTime { get; private set; }
        [JsonProperty("related_url")]
        public string RelatedUrl { get; private set; }
        [JsonProperty("shuo_topic")]
        public string ShuoTopic { get; private set; }
        [JsonProperty("cascade_invite")]
        public bool CascadeInvite { get; private set; }
        [JsonProperty("group_id")]
        public string GroupId { get; private set; }
        [JsonProperty("album_id")]
        public string AlbumId { get; private set; }
        [JsonProperty("participant_count")]
        public int ParticipantCount { get; private set; }
        [JsonProperty("photo_count")]
        public int PhotoCount { get; private set; }
        [JsonProperty("liked_count")]
        public int LikedCount { get; private set; }
        [JsonProperty("recs_count")]
        public int RecsCount { get; private set; }
        [JsonProperty("icon")]
        public string Icon { get; private set; }
        [JsonProperty("thumb")]
        public string Thumb { get; private set; }
        [JsonProperty("cover")]
        public string Cover { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("owner")]
        public UsrSimple Owner { get; private set; }
        [JsonProperty("liked")]
        public bool Liked { get; private set; }
        [JsonProperty("joined")]
        public bool Joined { get; private set; }
    }

    /// <summary>
    /// 线上活动搜索结果
    /// </summary>
    public class OnlSearch : SearchResult
    {
        [JsonProperty("onlines")]
        public List<OnlInfo> Onlines { get; private set; }
    }
    
    public static partial class API
    {
        /// <summary>
        /// 获取线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <returns>线上活动信息</returns>
        public static OnlInfo OnlGetOnline(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.ONLOP_ID, id));
            return (OnlInfo)Utilities.JsonDeserialize<OnlInfo>(result); 
        }
        
        /// <summary>
        /// 获取线上活动参加成员列表
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>用户搜索结果</returns>
        public static UsrSearch OnlGetPartUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLPARTOP_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (UsrSearch)Utilities.JsonDeserialize<UsrSearch>(result);
        }
        
        /// <summary>
        /// 获取线上活动论坛列表
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>讨论搜索结果</returns>
        public static DiscSearch OnlGetDiscs(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLDISCOP_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (DiscSearch)Utilities.JsonDeserialize<DiscSearch>(result);
        }
        
        /// <summary>
        /// 获取线上活动列表
        /// </summary>
        /// <param name="cate">类别(day/week/latest)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>线上活动搜索结果</returns>
        public static OnlSearch OnlGetOnlineList(string cate, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLLISTOP);
            Utilities.AddParam(ref ub, "cate", cate);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (OnlSearch)Utilities.JsonDeserialize<OnlSearch>(result);
        }
        
        /// <summary>
        /// 创建线上活动
        /// </summary>
        /// <param name="title">题目</param>
        /// <param name="desc">描述</param>
        /// <param name="beginTime">开始时间(不是是过去的时间, 时间格式"%Y-%m-%d %H:%M")</param>
        /// <param name="endTime">结束时间(不能早于开始时间, 活动期限不能长于90天)</param>
        /// <param name="relatedUrl">(可选)关联的url或者小组链接</param>
        /// <param name="cascadeInvite">(可选)是否允许参与的成员邀请朋友参加(false/true)</param>
        /// <param name="tags">(可选)标签(不超过4个, 用空格分开)</param>
        /// <returns>线上活动信息</returns>
        public static OnlInfo OnlPostOnline(string title, string desc, string beginTime, string endTime, string relatedUrl = null, string cascadeInvite = null, string tags = null)
        {
            string url = Utilities.CreateUrl(Common.ONLLISTOP);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("desc", desc);
            builder.Append("begin_time", beginTime);
            builder.Append("end_time", endTime);
            builder.Append("related_url", relatedUrl);
            builder.Append("cascade_invite", cascadeInvite);
            builder.Append("tags", tags);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (OnlInfo)Utilities.JsonDeserialize<OnlInfo>(result);
        }

        /// <summary>
        /// 更新线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="title">题目</param>
        /// <param name="desc">描述</param>
        /// <param name="beginTime">开始时间(不是是过去的时间, 时间格式"%Y-%m-%d %H:%M")</param>
        /// <param name="endTime">结束时间(不能早于开始时间, 活动期限不能长于90天)</param>
        /// <param name="relatedUrl">(可选)关联的url或者小组链接</param>
        /// <param name="cascadeInvite">(可选)是否允许参与的成员邀请朋友参加(false/true)</param>
        /// <param name="tags">(可选)标签(不超过4个, 用空格分开)</param>
        /// <returns>线上活动信息</returns>
        public static OnlInfo OnlRefreshOnline(string id, string title, string desc, string beginTime, string endTime, string relatedUrl = null, string cascadeInvite = null, string tags = null)
        {
            string url = Utilities.CreateUrl(Common.ONLOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("desc", desc);
            builder.Append("begin_time", beginTime);
            builder.Append("end_time", endTime);
            builder.Append("related_url", relatedUrl);
            builder.Append("cascade_invite", cascadeInvite);
            builder.Append("tags", tags);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (OnlInfo)Utilities.JsonDeserialize<OnlInfo>(result);
        }

        /// <summary>
        /// 删除线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        public static void OnlDeleteOnline(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.ONLOP_ID, id));
        }
        
        /// <summary>
        /// 参加线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <returns>线上活动信息</returns>
        public static OnlInfo OnlPostPart(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.ONLPARTOP_ID, id));
            return (OnlInfo)Utilities.JsonDeserialize<OnlInfo>(result);
        }

        /// <summary>
        /// 退出线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        public static void OnlDeletePart(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.ONLPARTOP_ID, id));
        }
        
        /// <summary>
        /// 喜欢线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <returns>线上活动信息</returns>
        public static OnlInfo OnlPostLike(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.ONLLIKEOP_ID, id));
            return (OnlInfo)Utilities.JsonDeserialize<OnlInfo>(result);
        }

        /// <summary>
        /// 取消喜欢线上活动
        /// </summary>
        /// <param name="id">活动id</param>
        public static void OnlDeleteLike(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.ONLLIKEOP_ID, id));
        }
        
        /// <summary>
        /// 获得图片列表
        /// </summary>
        /// <param name="id">相册id</param>
        /// <param name="order">(可选)顺序(desc/asc)</param>
        /// <param name="sortBy">(可选)排序方式(time/vote/comment)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>照片搜索结果</returns>
        public static PhoSearch OnlGetPhotos(string id, string order = null, string sortBy = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLPHOTOOP_ID, id);
            Utilities.AddParam(ref ub, "order", order);
            Utilities.AddParam(ref ub, "sort_by", sortBy);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (PhoSearch)Utilities.JsonDeserialize<PhoSearch>(result);
        }
        
        /// <summary>
        /// 上传图片(那肯定不行啊)
        /// </summary>
        /// <param name="id">相册id</param>
        /// <param name="image">照片名称</param>
        /// <param name="desc">(可选)照片描述</param>
        /// <returns>照片信息</returns>
        public static PhoInfo OnlPostPhoto(string id, string image, string desc = null)
        {
            string url = Utilities.CreateUrl(Common.ONLPHOTOOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("image", image);
            builder.Append("desc", desc);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (PhoInfo)Utilities.JsonDeserialize<PhoInfo>(result);
        }
        
        /// <summary>
        /// 线上活动论坛发贴
        /// </summary>
        /// <param name="id">讨论id</param>
        /// <param name="image">题目</param>
        /// <param name="desc">内容</param>
        /// <returns>讨论信息</returns>
        public static DiscInfo DiscPostDisc(string id, string title, string content)
        {
            string url = Utilities.CreateUrl(Common.ONLDISCOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (DiscInfo)Utilities.JsonDeserialize<DiscInfo>(result);
        }
        
        /// <summary>
        /// 获取用户参加的线上活动列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="exclude_expired">(可选)是否包括过期活动(true/false)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>线上活动搜索结果</returns>
        public static OnlSearch OnlGetUserParts(string id, bool? excludeExpired = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLUSERPARTS_ID, id);
            Utilities.AddParam(ref ub, "exclude_expired", excludeExpired);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (OnlSearch)Utilities.JsonDeserialize<OnlSearch>(result);
        }
        
        /// <summary>
        /// 获取用户创建的线上活动列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>线上活动搜索结果</returns>
        public static OnlSearch OnlGetUserCreates(int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.ONLUSERCREATES_ID);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (OnlSearch)Utilities.JsonDeserialize<OnlSearch>(result);
        }
    }
}