using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 讨论信息
    /// </summary>
    public class DiscInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("updated")]
        public string Updated { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
    }

    /// <summary>
    /// 讨论搜索结果
    /// </summary>
    public class DiscSearch : SearchResult
    {
        [JsonProperty("discussions")]
        public List<DiscInfo> Discussions { get; private set; }
    }
    
    public static partial class API
    {
        /// <summary>
        /// 获取讨论
        /// </summary>
        /// <param name="id">讨论id</param>
        /// <returns>讨论信息</returns>
        public static DiscInfo DiscGetDisc(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.DISCOP_ID, id));
            return (DiscInfo)Utilities.JsonDeserialize<DiscInfo>(result);
        }

        /// <summary>
        /// 更新讨论
        /// </summary>
        /// <param name="id">讨论id</param>
        /// <param name="image">题目</param>
        /// <param name="desc">内容</param>
        /// <returns>讨论信息</returns>
        public static DiscInfo DiscRefreshDisc(string id, string title, string content)
        {
            string url = Utilities.CreateUrl(Common.DISCOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (DiscInfo)Utilities.JsonDeserialize<DiscInfo>(result);
        }

        /// <summary>
        /// 删除讨论
        /// </summary>
        /// <param name="id">讨论id</param>
        public static void DiscDeleteDisc(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.DISCOP_ID, id));
        }

        /// <summary>
        /// 获取回复列表
        /// </summary>
        /// <param name="id">讨论id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>回复搜索结果</returns>
        public static CommSearch DiscGetComments(string id, int? start = null, int? count = null)
        {
            return CommGetComments(Common.DISCCOMMENTSOP_ID, id, start, count);
        }

        /// <summary>
        /// 新发回复
        /// </summary>
        /// <param name="id">讨论id</param>
        /// <param name="content">回复内容</param>
        /// <returns>回复信息</returns>
        public static CommInfo DiscPostComment(string id, string content)
        {
            return CommPostComment(Common.DISCCOMMENTSOP_ID, id, content);
        }

        /// <summary>
        /// 获取单条回复
        /// </summary>
        /// <param name="discId">讨论id</param>
        /// <param name="commentId">回复id</param>
        /// <returns>回复信息</returns>
        public static CommInfo DiscGetComment(string discId, string commentId)
        {
            return CommGetComment(Common.DISCCOMMENTOP_ID, discId, commentId);
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="discId">照片id</param>
        /// <param name="commentId">回复id</param>
        public static void DiscDeleteComment(string discId, string commentId)
        {
            CommDeleteComment(Common.DISCCOMMENTOP_ID, discId, commentId);
        }
    }
}