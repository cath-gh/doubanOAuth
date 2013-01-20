using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace doubanOAuth
{
    /// <summary>
    /// 日记信息
    /// </summary>
    public class NoteInfo
    {
        [JsonProperty("update_time")]
        public string UpdateTime { get; private set; }
        [JsonProperty("publish_time")]
        public string PublishTime { get; private set; }
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
        [JsonProperty("recs_count")]
        public int RecsCount { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("can_reply")]
        public bool CanReply { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("privacy")]
        public string Privacy { get; private set; }
        [JsonProperty("summary")]
        public string Summary { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; }
        [JsonProperty("liked_count")]
        public int LikedCount { get; private set; }
    }

    /// <summary>
    /// 日记搜索结果
    /// </summary>
    public class NoteSearch : SearchResult
    {
        [JsonProperty("notes")]
        public List<NoteInfo> Notes { get; private set; }
        [JsonProperty("user")]
        public UsrInfo User { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取用户的日记列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="format">(可选)日记内容格式(text/html_full/html_short/abstract/text)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>日记搜索结果</returns>
        public static NoteSearch NoteGetUserCreates(string id, string format = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.NOTEUSERCREATES_ID, id);
            Utilities.AddParam(ref ub, "format", format);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (NoteSearch)Utilities.JsonDeserialize<NoteSearch>(result);
        }

        /// <summary>
        /// 获取用户标记为喜欢的日记列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="format">(可选)日记内容格式(text/html_full/html_short/abstract/text)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>日记搜索结果</returns>
        public static NoteSearch NoteGetUserLikes(string id, string format = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.NOTEUSERLIKES_ID, id);
            Utilities.AddParam(ref ub, "format", format);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (NoteSearch)Utilities.JsonDeserialize<NoteSearch>(result);
        }

        ///// <summary>
        ///// 获取推荐给用户的日记列表
        ///// </summary>
        ///// <param name="id">用户id</param>
        ///// <param name="format">(可选)日记内容格式(text/html_full/html_short/abstract/text)</param>
        ///// <param name="start">(可选)取结果的offset</param>
        ///// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        ///// <returns>日记搜索结果</returns>
        //public static NoteSearch NoteGetUserGuesses(string id, string format = null, int? start = null, int? count = null)
        //{
        //    UriBuilder ub = Utilities.CreateUB(Common.NOTEUSERGUESSES_ID, id);
        //    Utilities.AddParam(ref ub, "format", format);
        //    Utilities.AddParam(ref ub, "start", start);
        //    Utilities.AddParam(ref ub, "count", count);
        //    string result = Utilities.RequestGet(ub.ToString(), true);
        //    return (NoteSearch)Utilities.JsonDeserialize<NoteSearch>(result);
        //}

        /// <summary>
        /// 获取一条日记
        /// </summary>
        /// <param name="id">日记id</param>
        /// <param name="format">(可选)日记内容格式(text/html_full/html_short/abstract/text)</param>
        /// <returns>日记信息</returns>
        public static NoteInfo NoteGetNote(string id, string format = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.NOTEOP_ID, id);
            Utilities.AddParam(ref ub, "format", format);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (NoteInfo)Utilities.JsonDeserialize<NoteInfo>(result);
        }

        /// <summary>
        /// 喜欢一条日记
        /// </summary>
        /// <param name="id">日记id</param>
        /// <returns>日记信息</returns>
        public static NoteInfo NotePostLike(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.NOTELIKEOP_ID, id));
            return (NoteInfo)Utilities.JsonDeserialize<NoteInfo>(result);
        }

        /// <summary>
        /// 取消喜欢一条日记
        /// </summary>
        /// <param name="id">日记id</param>
        public static void NoteDeleteLike(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.NOTELIKEOP_ID, id));
        }

        /// <summary>
        /// 增加一条日记(传图待测试)
        /// </summary>
        /// <param name="title">日记标题</param>
        /// <param name="privacy">隐私控制(public/friend/private)</param>
        /// <param name="canReply">是否允许回复</param>
        /// <param name="content">日记内容, 使用"<图片p_pid>"伪tag引用图片, 如果含链接, 使用html的链接标签格式, 或者直接使用网址</param>
        /// <param name="pids">(可选)上传的图片pid本地编号, 使用前缀"p_"</param>
        /// <param name="layoutPid">(可选)对应pid的排版</param>
        /// <param name="descPid">(可选)对应pid的图注</param>
        /// <param name="imagePid">(可选)对应pid的图片内容</param>
        /// <returns>日记信息</returns>
        public static NoteInfo NotePostNote(string title, string privacy, bool canReply, string content, string pids = null, string layoutPid = null, string descPid = null, string imagePid = null)
        {
            string url = Utilities.CreateUrl(Common.NOTEPOSTNOTE);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("privacy", privacy);
            builder.Append("can_reply", canReply);
            builder.Append("content", content);
            builder.Append("pids", pids);
            builder.Append("layout_pid", layoutPid);
            builder.Append("desc_pid", descPid);
            builder.Append("image_pid", imagePid);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (NoteInfo)Utilities.JsonDeserialize<NoteInfo>(result);
        }

        /// <summary>
        /// 更新一条日记
        /// </summary>
        /// <param name="id">日记id</param>
        /// <param name="title">日记标题</param>
        /// <param name="privacy">隐私控制(public, friend, private)</param>
        /// <param name="canReply">是否允许回复</param>
        /// <param name="content">日记内容, 使用"<图片p_pid>"伪tag引用图片, 如果含链接, 使用html的链接标签格式, 或者直接使用网址</param>
        /// <param name="pids">(可选)上传的图片pid本地编号, 使用前缀"p_"</param>
        /// <param name="layoutPid">(可选)对应pid的排版</param>
        /// <param name="descPid">(可选)对应pid的图注</param>
        /// <param name="imagePid">(可选)对应pid的图片内容</param>
        /// <returns>日记信息</returns>
        public static NoteInfo NoteRefreshNote(string id, string title, string privacy, bool canReply, string content, string pids = null, string layoutPid = null, string descPid = null, string imagePid = null)
        {
            string url = Utilities.CreateUrl(Common.NOTEOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("privacy", privacy);
            builder.Append("can_reply", canReply);
            builder.Append("content", content);
            builder.Append("pids", pids);
            builder.Append("layout_pid", layoutPid);
            builder.Append("desc_pid", descPid);
            builder.Append("image_pid", imagePid);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (NoteInfo)Utilities.JsonDeserialize<NoteInfo>(result);
        }

        /// <summary>
        /// 上传照片到日记(待测试)
        /// </summary>
        /// <param name="id">日记id</param>
        /// <param name="content">(可选)日记内容, 使用"<图片p_pid>"伪tag引用图片, 如果含链接, 使用html的链接标签格式, 或者直接使用网址</param>
        /// <param name="pids">(可选)上传的图片pid本地编号, 使用前缀"p_"</param>
        /// <param name="layoutPid">(可选)对应pid的排版</param>
        /// <param name="descPid">(可选)对应pid的图注</param>
        /// <param name="imagePid">(可选)对应pid的图片内容</param>
        /// <returns>日记信息</returns>
        public static NoteInfo NotePostImage(string id, string content, string pids = null, string layoutPid = null, string descPid = null, string imagePid = null)
        {
            string url = Utilities.CreateUrl(Common.NOTEOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("content", content);
            builder.Append("pids", pids);
            builder.Append("layout_pid", layoutPid);
            builder.Append("desc_pid", descPid);
            builder.Append("image_pid", imagePid);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (NoteInfo)Utilities.JsonDeserialize<NoteInfo>(result);
        }

        /// <summary>
        /// 删除一条日记
        /// </summary>
        /// <param name="id">日记id</param>
        public static void NoteDeleteNote(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.NOTEOP_ID, id));
        }

        /// <summary>
        /// 获取回复列表
        /// </summary>
        /// <param name="id">日记id</param>
        /// <param name="start">取结果的offset</param>
        /// <param name="count">取结果的条数</param>
        /// <returns>回复搜索结果</returns>
        public static CommSearch NoteGetComments(string id, int? start = null, int? count = null)
        {
            return CommGetComments(Common.NOTECOMMENTSOP_ID, id, start, count);
        }

        /// <summary>
        /// 新发回复
        /// </summary>
        /// <param name="id">日记id</param>
        /// <param name="content">回复内容</param>
        /// <returns>回复信息</returns>
        public static CommInfo NotePostComment(string id, string content)
        {
            return CommPostComment(Common.NOTECOMMENTSOP_ID, id, content);
        }

        /// <summary>
        /// 获取单条回复
        /// </summary>
        /// <param name="photoId">日记id</param>
        /// <param name="commentId">回复id</param>
        /// <returns>回复信息</returns>
        public static CommInfo NoteGetComment(string noteId, string commentId)
        {
            return CommGetComment(Common.NOTECOMMENTOP_ID, noteId, commentId);
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="noteId">日记id</param>
        /// <param name="commentId">回复id</param>
        public static void NoteDeleteComment(string noteId, string commentId)
        {
            CommDeleteComment(Common.NOTECOMMENTOP_ID, noteId, commentId);
        }
    }
}