using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 音乐信息
    /// </summary>
    public class MusInfo
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("author")]
        public List<Author> Author { get; private set; }
        [JsonProperty("alt_title")]
        public string AltTitle { get; private set; }
        [JsonProperty("tags")]
        public List<Tag> Tags { get; private set; }
        [JsonProperty("summary")]
        public string Summary { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("mobile_link")]
        public string MobileLink { get; private set; }
        [JsonProperty("attrs")]
        public MusAttr Attrs { get; private set; }
        [JsonProperty("rating")]
        public RatingItem Rating { get; private set; }
    }

    /// <summary>
    /// 音乐评论
    /// </summary>
    public class MusReview
    {
        [JsonProperty("Rating")]
        public Rating Rating { get; private set; }
        [JsonProperty("updated")]
        public string Updated { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("votes")]
        public int Votes { get; private set; }
        [JsonProperty("comments")]
        public int Comments { get; private set; }
        [JsonProperty("summary")]
        public string Summary { get; private set; }
        [JsonProperty("music")]
        public MusInfo Music { get; private set; }
        [JsonProperty("useless")]
        public int Useless { get; private set; }
        [JsonProperty("published")]
        public string Published { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
    }

    /// <summary>
    /// 音乐标签
    /// </summary>
    public class MusTag
    {
        [JsonProperty("count")]
        public int Count { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
    }

    /// <summary>
    /// 音乐属性
    /// </summary>
    public class MusAttr
    {
        [JsonProperty("publisher")]
        public List<string> Publisher { get; private set; }
        [JsonProperty("singer")]
        public List<string> Singer { get; private set; }
        [JsonProperty("discs")]
        public List<string> Discs { get; private set; }
        [JsonProperty("pubdate")]
        public List<string> PubDate { get; private set; }
        [JsonProperty("title")]
        public List<string> Title { get; private set; }
        [JsonProperty("media")]
        public List<string> Media { get; private set; }
        [JsonProperty("tracks")]
        public List<string> Tracks { get; private set; }
        [JsonProperty("version")]
        public List<string> Version { get; private set; }
    }
    
    /// <summary>
    /// 音乐搜索结果
    /// </summary>
    public class MusSearch : SearchResult
    {
        [JsonProperty("musics")]
    	public List<MusInfo> Musics { get; private set; }
    }
    
    /// <summary>
    /// 音乐标签搜索结果
    /// </summary>
    public class MusTagSearch : SearchResult
    {
        [JsonProperty("tags")]
    	public List<MusTag> Tags { get; private set; }
    }
    
    public static partial class API
    {
    	/// <summary>
    	/// 获取音乐信息
    	/// </summary>
    	/// <param name="id">音乐id</param>
    	/// <returns>音乐信息</returns>
    	public static MusInfo MusGetMusic_Id(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.MUSINFO_ID, id));
            return (MusInfo)Utilities.JsonDeserialize<MusInfo>(result);
        }
    	
    	/// <summary>
        /// 搜索音乐
        /// </summary>
        /// <param name="keyword">(keyword/tag)查询关键字</param>
        /// <param name="tag">(keyword/tag)查询的tag</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>音乐搜索结果</returns>
        public static MusSearch MusSearch(string keyword = null, string tag = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MUSSEARCH);
            Utilities.AddParam(ref ub, "q", keyword);
            Utilities.AddParam(ref ub, "tag", tag);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MusSearch)Utilities.JsonDeserialize<MusSearch>(result);
        }
    	
    	/// <summary>
        /// 获取某个音乐中标记最多的标签
        /// </summary>
        /// <param name="id">音乐id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>音乐标签搜索结果</returns>
        public static MusTagSearch MusGetMusTopTags(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MUSTOPTAGS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MusTagSearch)Utilities.JsonDeserialize<MusTagSearch>(result);
        }
        
        /// <summary>
        /// 发表新评论
        /// </summary>
        /// <param name="id">音乐id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>音乐评论</returns>
        public static MusReview MusPostReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.MUSPOSTREVIEW);
            StringBuilder builder = new StringBuilder();
            builder.Append("music", id);
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (MusReview)Utilities.JsonDeserialize<MusReview>(result);
        }

        /// <summary>
        /// 修改评论
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>音乐评论</returns>
        public static MusReview MusEditReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.MUSREVIEWOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (MusReview)Utilities.JsonDeserialize<MusReview>(result);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论id</param>
        public static void MusDeleteReview(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.MUSREVIEWOP_ID, id));
        }

        /// <summary>
        /// 获取用户对音乐的所有标签
        /// </summary>
        /// <param name="name">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>音乐标签搜索结果</returns>
        public static MusTagSearch MusGetUserTags(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MUSUSERTAGS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MusTagSearch)Utilities.JsonDeserialize<MusTagSearch>(result);
        }
    }
}
