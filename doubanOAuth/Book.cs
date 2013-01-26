using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace doubanOAuth
{
    /// <summary>
    /// 图书信息
    /// </summary>
    public class BkInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("isbn10")]
        public string ISBN10 { get; private set; }
        [JsonProperty("isbn13")]
        public string ISBN13 { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("origin_title")]
        public string OriginTitle { get; private set; }
        [JsonProperty("alt_title")]
        public string AltTitle { get; private set; }
        [JsonProperty("subtitle")]
        public string SubTitle { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("images")]
        public BKImages Images { get; private set; }
        [JsonProperty("author")]
        public List<string> Author { get; private set; }
        [JsonProperty("translator")]
        public List<string> Translator { get; private set; }
        [JsonProperty("publisher")]
        public string Publisher { get; private set; }
        [JsonProperty("pubdate")]
        public string PubDate { get; private set; }
        [JsonProperty("rating")]
        public RatingItem Rating { get; private set; }
        [JsonProperty("tags")]
        public List<Tag> Tags { get; private set; }
        [JsonProperty("binding")]
        public string Binding { get; private set; }
        [JsonProperty("price")]
        public string Price { get; private set; }
        [JsonProperty("pages")]
        public string Pages { get; private set; }
        [JsonProperty("author_intro")]
        public string AnthorIntro { get; private set; }
        [JsonProperty("summary")]
        public string Summary { get; private set; }
    }

    /// <summary>
    /// 图书评论
    /// </summary>
    public class BkReview
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
        [JsonProperty("book")]
        public BkInfo Book { get; private set; }
        [JsonProperty("rating")]
        public Rating Rating { get; private set; }
        [JsonProperty("votes")]
        public int Votes { get; private set; }
        [JsonProperty("useless")]
        public int Useless { get; private set; }
        [JsonProperty("comments")]
        public int Comments { get; private set; }
        [JsonProperty("summary")]
        public int Summary { get; private set; }
        [JsonProperty("published")]
        public string Published { get; private set; }
        [JsonProperty("updated")]
        public string Updated { get; private set; }
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class Tag
    {
        [JsonProperty("count")]
        public int Count { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
    }

    /// <summary>
    /// 标签
    /// </summary>
    public class TaginAll
    {
        [JsonProperty("count")]
        public int Count { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
    }

    /// <summary>
    /// 图书收藏
    /// </summary>
    public class BkCollection
    {
        [JsonProperty("book")]
        public BkInfo Book { get; private set; }
        [JsonProperty("book_id")]
        public string BookId { get; private set; }
        [JsonProperty("comment")]
        public string Comment { get; private set; }
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("rating")]
        public Rating Rating { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; private set; }
        [JsonProperty("updated")]
        public string Updated { get; private set; }
        [JsonProperty("user_id")]
        public string UserId { get; private set; }
    }

    /// <summary>
    /// 图书笔记
    /// </summary>
    public class BkAnnotation
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("book_id")]
        public string BookId { get; private set; }
        [JsonProperty("book")]
        public BkInfo Book { get; private set; }
        [JsonProperty("author_id")]
        public string AuthorId { get; private set; }
        [JsonProperty("author_user")]
        public UsrSimple AuthorUser { get; private set; }
        [JsonProperty("chapter")]
        public string Chapter { get; private set; }
        [JsonProperty("page_no")]
        public int PageNo { get; private set; }
        [JsonProperty("privacy")]
        public int Privacy { get; private set; }
        [JsonProperty("abstract")]
        public string Abstract { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
        [JsonProperty("abstract_photo")]
        public string AbstractPhoto { get; private set; }
        [JsonProperty("photos")]
        private object _photos;
        private string _oldPhotos;
        private List<string> _phoList = new List<string>();
        public List<string> Photos
        {
            get
            {
                string phoStr = _photos.ToString();
                if (!String.Equals(phoStr, _oldPhotos))
                {
                    string pattern = ": \"(?<url>[^\"]*)";
                    MatchCollection mc = Regex.Matches(phoStr, pattern);
                    foreach (Match m in mc)
                    {
                        _phoList.Add(m.Groups["url"].ToString());
                    }
                    _oldPhotos = phoStr;
                }
                return _phoList;
            }
        }
        [JsonProperty("last_photo")]
        public int LastPhoto { get; private set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; }
        [JsonProperty("hasmath")]
        public bool Hasmath { get; private set; }
        [JsonProperty("time")]
        public string Time { get; private set; }
    }

    /// <summary>
    /// 图书的大中小三中图片
    /// </summary>
    public class BKImages
    {
        [JsonProperty("small")]
        public string Small { get; private set; }
        [JsonProperty("large")]
        public string medium { get; private set; }
        [JsonProperty("medium")]
        public string Medium { get; private set; }
    }

    /// <summary>
    /// 图书搜索结果
    /// </summary>
    public class BkSearch : SearchResult
    {
        [JsonProperty("books")]
        public List<BkInfo> Books { get; private set; }
    }

    /// <summary>
    /// 图书标签搜索结果(temp)
    /// </summary>
    public class BkTagSearch : SearchResult
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; private set; }
    }

    /// <summary>
    /// 图书标签搜索结果(temp)
    /// </summary>
    public class BkTagSearchinAll : SearchResult
    {
        [JsonProperty("tags")]
        public List<TaginAll> Tags { get; private set; }
    }

    /// <summary>
    /// 图书收藏搜索结果
    /// </summary>
    public class BkColSearch : SearchResult
    {
        [JsonProperty("collections")]
        public List<BkCollection> Collections { get; private set; }
    }

    /// <summary>
    /// 图书笔记搜索结果
    /// </summary>
    public class BkAnnoSearch : SearchResult
    {
        [JsonProperty("annotations")]
        public List<BkAnnotation> Annotation { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取图书信息
        /// </summary>
        /// <param name="id">图书id</param>
        /// <returns>图书信息</returns>
        public static BkInfo BkGetBook_Id(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.BKINFO_ID, id));
            return (BkInfo)Utilities.JsonDeserialize<BkInfo>(result);
        }

        /// <summary>
        /// 获取图书信息
        /// </summary>
        /// <param name="isbn">图书isbn</param>
        /// <returns>图书信息</returns>
        public static BkInfo BkGetBook_Isbn(string isbn)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.BKINFO_NAME, isbn));
            return (BkInfo)Utilities.JsonDeserialize<BkInfo>(result);
        }

        /// <summary>
        /// 搜索图书
        /// </summary>
        /// <param name="keyword">(keyword/tag)查询关键字</param>
        /// <param name="tag">(keyword/tag)查询的tag</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书搜索结果</returns>
        public static BkSearch BkSearch(string keyword = null, string tag = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKSEARCH);
            Utilities.AddParam(ref ub, "q", keyword);
            Utilities.AddParam(ref ub, "tag", tag);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkSearch)Utilities.JsonDeserialize<BkSearch>(result);
        }

        /// <summary>
        /// 搜索某个图书中标记最多的标签
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书标签搜索结果</returns>
        public static BkTagSearch BkGetBookTopTags(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKTOPTAGS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkTagSearch)Utilities.JsonDeserialize<BkTagSearch>(result);
        }

        /// <summary>
        /// 发表新评论
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>图书评论</returns>
        public static BkReview BkPostReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.BKPOSTREVIEW);
            StringBuilder builder = new StringBuilder();
            builder.Append("book", id);
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (BkReview)Utilities.JsonDeserialize<BkReview>(result);
        }

        /// <summary>
        /// 修改评论
        /// </summary>
        /// <param name="id">评论id</param>
        /// <param name="title">评论标题</param>
        /// <param name="content">评论内容(多于150字)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>图书评论</returns>
        public static BkReview BkEditReview(string id, string title, string content, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.BKREVIEWOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("rating", rating);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (BkReview)Utilities.JsonDeserialize<BkReview>(result);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">评论id</param>
        public static void BkDeleteReview(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.BKREVIEWOP_ID, id));
        }

        /// <summary>
        /// 获取用户对图书的所有标签
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书标签搜索结果</returns>
        public static BkTagSearchinAll BkGetUserTags(string name, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKUSERTAGS_NAME, name);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkTagSearchinAll)Utilities.JsonDeserialize<BkTagSearchinAll>(result);
        }

        /// <summary>
        /// 获取某个用户的所有图书收藏信息
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="status">(可选)收藏状态(想读: wish, 在读: reading, 读过: read, 默认为所有状态)</param>
        /// <param name="tag">(可选)收藏标签</param>
        /// <param name="from">(可选)起始时间(符合rfc3339的字符串, 例如"2012-10-19T17:14:11")</param>
        /// <param name="to">(可选)结束时间</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书收藏搜索结果</returns>
        public static BkColSearch BkGetUserCols(string name, string status = null, string tag = null, string from = null, string to = null, int? rating = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKUSERCOLS_NAME, name);
            Utilities.AddParam(ref ub, "status", status);
            Utilities.AddParam(ref ub, "tag", tag);
            Utilities.AddParam(ref ub, "from", from);
            Utilities.AddParam(ref ub, "to", to);
            Utilities.AddParam(ref ub, "rating", rating);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkColSearch)Utilities.JsonDeserialize<BkColSearch>(result);
        }

        /// <summary>
        /// 获取用户对某本图书的收藏信息
        /// </summary>
        /// <param name="id">图书id</param>
        /// <returns>图书收藏</returns>
        public static BkCollection BkGetCol(string id)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKUSERCOL_ID, id);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (BkCollection)Utilities.JsonDeserialize<BkCollection>(result);
        }

        /// <summary>
        /// 用户收藏某本图书
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="status">收藏状态(想读: wish, 在读: reading, 读过: read)</param>
        /// <param name="tags">(可选)收藏标签(用空格分隔)</param>
        /// <param name="comment">(可选)短评文本(最多350字)</param>
        /// <param name="privacy">(可选)隐私设置('private'为设置仅自己可见)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>图书收藏</returns>
        public static BkCollection BkPostCollection(string id, string status, string tags = null, string comment = null, string privacy = null, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.BKCOLOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("status", status);
            builder.Append("tags", tags);
            builder.Append("comment", comment);
            builder.Append("privacy", privacy);
            builder.Append("rating", rating);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (BkCollection)Utilities.JsonDeserialize<BkCollection>(result);
        }

        /// <summary>
        /// 用户修改对某本图书的收藏
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="status">收藏状态(想读: wish, 在读: reading, 读过: read)</param>
        /// <param name="tags">(可选)收藏标签(用空格分隔)</param>
        /// <param name="comment">(可选)短评文本(最多350字)</param>
        /// <param name="privacy">(可选)隐私设置('private'为设置仅自己可见)</param>
        /// <param name="rating">(可选)评分(数字1 - 5为合法值)</param>
        /// <returns>图书收藏</returns>
        public static BkCollection BkEditCollection(string id, string status, string tags = null, string comment = null, string privacy = null, int? rating = null)
        {
            string url = Utilities.CreateUrl(Common.BKCOLOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("status", status);
            builder.Append("tags", tags);
            builder.Append("comment", comment);
            builder.Append("privacy", privacy);
            builder.Append("rating", rating);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (BkCollection)Utilities.JsonDeserialize<BkCollection>(result);
        }

        /// <summary>
        /// 用户删除对某本图书的收藏
        /// </summary>
        /// <param name="id">图书id</param>
        public static void BkDeleteCollection(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.BKCOLOP_ID, id));
        }

        /// <summary>
        /// 获取某个用户的所有笔记
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书笔记搜索结果</returns>
        public static BkAnnoSearch BkGetUserAnnos(string name, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKUSERANNOS_NAME, name);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkAnnoSearch)Utilities.JsonDeserialize<BkAnnoSearch>(result);
        }

        /// <summary>
        /// 获取某本图书的所有笔记
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="format">(可选)content字段格式(text/html)</param>
        /// <param name="order">(可选)排序(按有用程度: rank, 最新笔记: collect, 按页码先后: page)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>图书笔记搜索结果</returns>
        public static BkAnnoSearch BkGetBookAnnos(string id, string format = null, string order = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKANNOS_ID, id);
            Utilities.AddParam(ref ub, "format", format);
            Utilities.AddParam(ref ub, "order", order);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (BkAnnoSearch)Utilities.JsonDeserialize<BkAnnoSearch>(result);
        }

        /// <summary>
        /// 获取某篇笔记的信息
        /// </summary>
        /// <param name="id">笔记id</param>
        /// <param name="format">(可选)content字段格式(text/html)</param>
        /// <returns>图书笔记</returns>
        public static BkAnnotation BkGetAnno(string id, string format = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.BKANNO_ID, id);
            Utilities.AddParam(ref ub, "format", format);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (BkAnnotation)Utilities.JsonDeserialize<BkAnnotation>(result);
        }

        /// <summary>
        /// 用户给某本图书写笔记
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="content">笔记内容(多余15字)</param>
        /// <param name="page">(page/chapter)页码</param>
        /// <param name="chapter">(page/chapter)章节名</param>
        /// <param name="privacy">(可选)隐私设置(值为'private'为设置仅自己可见)</param>
        /// <param name="imagePath">(可选)图片路径</param>
        /// <returns>图书笔记</returns>
        public static BkAnnotation BkPostAnno(string id, string content, int? page = null, string chapter = null, string privacy = null, List<string> imagePath = null)
        {
            string url = Utilities.CreateUrl(Common.BKPOSTANNO_ID, id);
            FormData fd = new FormData();
            fd.AddParam("content", content);
            fd.AddParam("page", page);
            fd.AddParam("chapter", chapter);
            fd.AddParam("privacy", privacy);
            if (imagePath != null)
            {
                for (int i = 0; i < imagePath.Count; i++)
                    fd.AddParam((i + 1).ToString(), "image/jpeg", imagePath[i]);
            }
            string result = Utilities.RequestPostFile(url, fd.GetBytes());
            return (BkAnnotation)Utilities.JsonDeserialize<BkAnnotation>(result);
        }

        /// <summary>
        /// 用户更新某篇笔记
        /// </summary>
        /// <param name="id">图书id</param>
        /// <param name="content">笔记内容(多余15字)</param>
        /// <param name="page">(page/chapter)页码</param>
        /// <param name="chapter">(page/chapter)章节名</param>
        /// <param name="privacy">(可选)隐私设置(值为'private'为设置仅自己可见)</param>
        /// <param name="imagePath">(可选)图片路径</param>
        /// <returns>图书笔记</returns>
        public static BkAnnotation BkRefreshAnno(string id, string content, int? page = null, string chapter = null, string privacy = null, List<string> imagePath = null)
        {
            string url = Utilities.CreateUrl(Common.BKANNOOP_ID, id);
            FormData fd = new FormData();
            fd.AddParam("content", content);
            fd.AddParam("page", page);
            fd.AddParam("chapter", chapter);
            fd.AddParam("privacy", privacy);
            if (imagePath != null)
            {
                for (int i = 0; i < imagePath.Count; i++)
                    fd.AddParam((i + 1).ToString(), "image/jpeg", imagePath[i]);
            }
            string result = Utilities.RequestPutFile(url, fd.GetBytes());
            return (BkAnnotation)Utilities.JsonDeserialize<BkAnnotation>(result);
        }
        
        /// <summary>
        /// 用户删除某篇笔记
        /// </summary>
        /// <param name="id">笔记id</param>
        public static void BkDeleteAnno(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.BKANNOOP_ID, id));
        }
    }
}
