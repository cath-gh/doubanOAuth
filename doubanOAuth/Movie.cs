using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 电影信息
    /// </summary>
    public class MovInfo
    {
        [JsonProperty("rating")]
        public RatingItem Rating { get; private set; }
        [JsonProperty("author")]
        public List<Author> Author { get; private set; }
        [JsonProperty("alt_title")]
        public string AltTitle { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("mobile_link")]
        public string MobileLink { get; private set; }
        [JsonProperty("summary")]
        public string Summary { get; private set; }
        [JsonProperty("attrs")]
        public MovAttr Attrs { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("tags")]
        public List<Tag> Tags { get; private set; }
    }

    /// <summary>
    /// 电影评论
    /// </summary>
    public class MovReview
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
        [JsonProperty("movie")]
        public MovInfo Movie { get; private set; }
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
    /// 电影标签
    /// </summary>
    public class MovTag
    {
        [JsonProperty("count")]
        public int Count { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
    }

    /// <summary>
    /// 电影属性
    /// </summary>
    public class MovAttr
    {
        [JsonProperty("language")]
        public List<string> Language { get; private set; }
        [JsonProperty("pubdate")]
        public List<string> PubDate { get; private set; }
        [JsonProperty("title")]
        public List<string> Title { get; private set; }
        [JsonProperty("country")]
        public List<string> Country { get; private set; }
        [JsonProperty("writer")]
        public List<string> Writer { get; private set; }
        [JsonProperty("director")]
        public List<string> Director { get; private set; }
        [JsonProperty("cast")]
        public List<string> Cast { get; private set; }
        [JsonProperty("movie_duration")]
        public List<string> MovieDuration { get; private set; }
        [JsonProperty("year")]
        public List<string> Year { get; private set; }
        [JsonProperty("movie_type")]
        public List<string> MovieType { get; private set; }
    }
    
    /// <summary>
    /// 电影搜索结果
    /// </summary>
    public class MovSearch : SearchResult
    {
        [JsonProperty("movies")]
    	public List<MovInfo> Movies { get; private set; }
    }
    
    /// <summary>
    /// 电影标签搜索结果
    /// </summary>
    public class MovTagSearch : SearchResult
    {
        [JsonProperty("tags")]
    	public List<MovTag> Tags { get; private set; }
    }
    
    public static partial class API
    {
    	/// <summary>
    	/// 获取电影信息
    	/// </summary>
    	/// <param name="id">电影id</param>
    	/// <returns>电影信息</returns>
    	public static MovInfo MovGetMovie_Id(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.MOVINFO_ID, id));
            return (MovInfo)Utilities.JsonDeserialize<MovInfo>(result);
        }
    	
    	/// <summary>
    	/// 获取电影信息
    	/// </summary>
    	/// <param name="imdb">电影imdb</param>
    	/// <returns>电影信息</returns>
    	public static MovInfo MovGetMovie_Imdb(string imdb)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.MOVINFO_IMDB, imdb));
            return (MovInfo)Utilities.JsonDeserialize<MovInfo>(result);
        }
    	
    	/// <summary>
        /// 搜索电影
        /// </summary>
        /// <param name="keyword">(keyword/tag)查询关键字</param>
        /// <param name="tag">(keyword/tag)查询的tag</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>电影搜索结果</returns>
        public static MovSearch MovSearch(string keyword = null, string tag = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MOVSEARCH);
            Utilities.AddParam(ref ub, "q", keyword);
            Utilities.AddParam(ref ub, "tag", tag);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MovSearch)Utilities.JsonDeserialize<MovSearch>(result);
        }
    	
    	/// <summary>
        /// 某个电影中标记最多的标签
        /// </summary>
        /// <param name="id">电影id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>电影标签搜索结果</returns>
        public static MovTagSearch MovGetMovTopTags(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MOVTOPTAGS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MovTagSearch)Utilities.JsonDeserialize<MovTagSearch>(result);
        }
        
        /// <summary>
        /// 发表新评论
        /// </summary>
        /// <param name="id">电影id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>电影评论</returns>
        public static MovReview MovPostReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.MOVPOSTREVIEW);
            StringBuilder builder = new StringBuilder();
            builder.Append("movie", id);
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (MovReview)Utilities.JsonDeserialize<MovReview>(result);
        }

        /// <summary>
        /// 修改评论
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>电影评论</returns>
        public static MovReview MovEditReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.MOVREVIEWOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (MovReview)Utilities.JsonDeserialize<MovReview>(result);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论id</param>
        public static void MovDeleteReview(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.MOVREVIEWOP_ID, id));
        }

        /// <summary>
        /// 获取用户对电影的所有标签
        /// </summary>
        /// <param name="name">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>电影标签搜索结果</returns>
        public static MovTagSearch MovGetUserTags(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MOVUSERTAGS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (MovTagSearch)Utilities.JsonDeserialize<MovTagSearch>(result);
        }
    }
}
