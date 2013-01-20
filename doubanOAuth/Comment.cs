using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 回复信息
    /// </summary>
    public class CommInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
    }

    /// <summary>
    /// 回复搜索结果
    /// </summary>
    public class CommSearch : SearchResult
    {
        [JsonProperty("comments")]
        public List<CommInfo> Comments { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取回复列表
        /// </summary>
        /// <param name="target">目标url</param>
        /// <param name="id">目标id</param>
        /// <param name="start">取结果的offset</param>
        /// <param name="count">取结果的条数</param>
        /// <returns>回复搜索结果</returns>
        public static CommSearch CommGetComments(string target, string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(target, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (CommSearch)Utilities.JsonDeserialize<CommSearch>(result);
        }

        /// <summary>
        /// 新发回复
        /// </summary>
        /// <param name="target">目标url</param>
        /// <param name="id">目标id</param>
        /// <param name="content">回复内容</param>
        /// <returns>回复信息</returns>
        public static CommInfo CommPostComment(string target, string id, string content)
        {
            string url = Utilities.CreateUrl(target, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("content", content);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (CommInfo)Utilities.JsonDeserialize<CommInfo>(result);
        }

        /// <summary>
        /// 获取单条回复
        /// </summary>
        /// <param name="target">目标url</param>
        /// <param name="photoId">目标id</param>
        /// <param name="commentId">回复id</param>
        /// <returns>回复信息</returns>
        public static CommInfo CommGetComment(string target, string targetId, string commentId)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(target, targetId, commentId), true);
            return (CommInfo)Utilities.JsonDeserialize<CommInfo>(result);
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="target">目标url</param>
        /// <param name="photoId">目标id</param>
        /// <param name="commentId">回复id</param>
        public static void CommDeleteComment(string target, string targetId, string commentId)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(target, targetId, commentId));
        }
    }
}
