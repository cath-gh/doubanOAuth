using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 照片信息
    /// </summary>
    public class PhoInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("album_id")]
        public string AlbumId { get; private set; }
        [JsonProperty("album_title")]
        public string AlbumTitle { get; private set; }
        [JsonProperty("icon")]
        public string Icon { get; private set; }
        [JsonProperty("cover")]
        public string Cover { get; private set; }
        [JsonProperty("thumb")]
        public string Thumb { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("desc")]
        public string Desc { get; private set; }
        [JsonProperty("privacy")]
        public string Privacy { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("position")]
        public int Position { get; private set; }
        [JsonProperty("prev_photo")]
        public string PrevPhoto { get; private set; }
        [JsonProperty("next_photo")]
        public string NextPhoto { get; private set; }
        [JsonProperty("liked_count")]
        public int LikedCount { get; private set; }
        [JsonProperty("recs_count")]
        public int RecsCount { get; private set; }
        [JsonProperty("comments_count")]
        public int CommentsCount { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
        [JsonProperty("liked")]
        public bool Liked { get; private set; }
        [JsonProperty("sizes")]
        public PhoSize Sizes { get; private set; }
    }

    /// <summary>
    /// 相册信息
    /// </summary>
    public class PhoAlbum
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("icon")]
        public string Icon { get; private set; }
        [JsonProperty("cover")]
        public string Cover { get; private set; }
        [JsonProperty("thumb")]
        public string Thumb { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("privacy")]
        public string Privacy { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("updated")]
        public string Updated { get; private set; }
        [JsonProperty("liked_count")]
        public int LikedCount { get; private set; }
        [JsonProperty("recs_count")]
        public int RecsCount { get; private set; }
        [JsonProperty("size")]
        public int Size { get; private set; }
        [JsonProperty("desc")]
        public string Desc { get; private set; }
        [JsonProperty("author")]
        public UsrSimple Author { get; private set; }
        [JsonProperty("liked")]
        public bool Liked { get; private set; }
        [JsonProperty("sizes")]
        public PhoSize Sizes { get; private set; }
    }

    /// <summary>
    /// 照片Sizes
    /// </summary>
    public class PhoSize
    {
        [JsonProperty("image")]
        public List<int> Image { get; private set; }
        [JsonProperty("cover")]
        public List<int> Cover { get; private set; }
        [JsonProperty("thumb")]
        public List<int> Thumb { get; private set; }
        [JsonProperty("icon")]
        public List<int> Icon { get; private set; }
    }

    /// <summary>
    /// 照片搜索结果
    /// </summary>
    public class PhoSearch : SearchResult
    {
        [JsonProperty("photos")]
        public List<PhoInfo> Photos { get; private set; }
        [JsonProperty("album")]
        public PhoAlbum Album { get; private set; }
        [JsonProperty("sortby")]
        public string SortBy { get; private set; }
        [JsonProperty("order")]
        public string Order { get; private set; }
    }

    /// <summary>
    ///  相册搜索结果
    /// </summary>
    public class PhoAlbumSearch : SearchResult
    {
        [JsonProperty("albums")]
        public List<PhoInfo> Albums { get; private set; }
        [JsonProperty("user")]
        public UsrInfo User { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取相册
        /// </summary>
        /// <param name="id">相册id</param>
        /// <returns>相册信息</returns>
        public static PhoAlbum PhoGetAlbum(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.PHOALBUMOP_ID, id), true);
            return (PhoAlbum)Utilities.JsonDeserialize<PhoAlbum>(result);
        }

        /// <summary>
        /// 创建相册
        /// </summary>
        /// <param name="title">相册名</param>
        /// <param name="desc">(可选)相册描述</param>
        /// <param name="order">(可选)顺序(desc/asc)</param>
        /// <param name="privacy">(可选)可见性(public/friend/private)</param>
        /// <returns>相册信息</returns>
        public static PhoAlbum PhoCreateAlbum(string title, string desc = null, string order = null, string privacy = null)
        {
            string url = Utilities.CreateUrl(Common.PHOCREATEALBUM);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("desc", desc);
            builder.Append("order", order);
            builder.Append("privacy", privacy);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (PhoAlbum)Utilities.JsonDeserialize<PhoAlbum>(result);
        }

        /// <summary>
        /// 更新相册
        /// </summary>
        /// <param name="id">相册id</param>
        /// <param name="title">相册名</param>
        /// <param name="desc">(可选)相册描述</param>
        /// <param name="order">(可选)顺序(desc/asc)</param>
        /// <param name="privacy">(可选)可见性(public/friend/private)</param>
        /// <returns>相册信息</returns>
        public static PhoAlbum PhoRefreshAlbum(string id, string title, string desc = null, string order = null, string privacy = null)
        {
            string url = Utilities.CreateUrl(Common.PHOALBUMOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("desc", desc);
            builder.Append("order", order);
            builder.Append("privacy", privacy);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (PhoAlbum)Utilities.JsonDeserialize<PhoAlbum>(result);
        }

        /// <summary>
        /// 删除相册
        /// </summary>
        /// <param name="id">相册id</param>
        public static void PhoDeleteAlbum(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.PHOALBUMOP_ID, id));
        }

        /// <summary>
        /// 获得相册照片列表
        /// </summary>
        /// <param name="id">相册id</param>
        /// <param name="order">(可选)顺序(desc/asc)</param>
        /// <param name="sortBy">(可选)排序方式(time/vote/comment)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>照片搜索结果</returns>
        public static PhoSearch PhoGetAlbumPhotos(string id, string order = null, string sortBy = null, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.PHOLIST_ID, id);
            Utilities.AddParam(ref ub, "order", order);
            Utilities.AddParam(ref ub, "sort_by", sortBy);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (PhoSearch)Utilities.JsonDeserialize<PhoSearch>(result);
        }

        /// <summary>
        /// 喜欢相册
        /// </summary>
        /// <param name="id">相册id</param>
        /// <returns>相册信息</returns>
        public static PhoAlbum PhoPostLikeAlbum(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.PHOALBUMLIKEOP_ID, id));
            return (PhoAlbum)Utilities.JsonDeserialize<PhoAlbum>(result);
        }

        /// <summary>
        /// 取消喜欢相册
        /// </summary>
        /// <param name="id">相册id</param>
        public static void PhoDeleteLikeAlbum(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.PHOALBUMLIKEOP_ID, id));
        }

        /// <summary>
        /// 获取用户相册列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>相册搜索结果</returns>
        public static PhoAlbumSearch PhoGetUserCreateAlbs(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.PHOUSERCREATEALBS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (PhoAlbumSearch)Utilities.JsonDeserialize<PhoAlbumSearch>(result);
        }

        /// <summary>
        /// 获得用户喜欢的相册列表
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>相册搜索结果</returns>
        public static PhoAlbumSearch PhoGetLikeAlbs(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.PHOUSERLIKEALBS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (PhoAlbumSearch)Utilities.JsonDeserialize<PhoAlbumSearch>(result);
        }

        /// <summary>
        /// 获得照片
        /// </summary>
        /// <param name="id">照片id</param>
        /// <returns>照片信息</returns>
        public static PhoInfo PhoGetPhoto(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.PHOOP_ID, id), true);
            return (PhoInfo)Utilities.JsonDeserialize<PhoInfo>(result);
        }

        /// <summary>
        /// 上传照片
        /// </summary>
        /// <param name="id">相册id</param>
        /// <param name="imagePath">照片路径</param>
        /// <param name="desc">(可选)照片描述</param>
        /// <returns>照片信息</returns>
        public static PhoInfo PhoPostPhoto(string id, string imagePath, string desc = null)
        {
            string url = Utilities.CreateUrl(Common.PHOALBUMOP_ID, id);
            FormData fd = new FormData();
            fd.AddParam("desc", desc);
            fd.AddParam("image", "image/jpeg", imagePath);
            string result = Utilities.RequestPostFile(url, fd.GetBytes());
            return (PhoInfo)Utilities.JsonDeserialize<PhoInfo>(result);
        }

        /// <summary>
        /// 更新照片描述
        /// </summary>
        /// <param name="id">照片id</param>
        /// <param name="image">照片名称</param>
        /// <param name="desc">(可选)照片描述</param>
        /// <returns>照片信息</returns>
        public static PhoInfo PhoRefreshPhotoDesc(string id, string desc = null)
        {
            string url = Utilities.CreateUrl(Common.PHOOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("desc", desc);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (PhoInfo)Utilities.JsonDeserialize<PhoInfo>(result);
        }

        /// <summary>
        /// 删除照片
        /// </summary>
        /// <param name="id">照片id</param>
        public static void PhoDeletePhoto(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.PHOOP_ID, id));
        }

        /// <summary>
        /// 喜欢照片
        /// </summary>
        /// <param name="id">照片id</param>
        /// <returns>相册信息</returns>
        public static PhoInfo PhoPostLike(string id)
        {
            string result = Utilities.RequestPost(Utilities.CreateUrl(Common.PHOLIKEOP_ID, id));
            return (PhoInfo)Utilities.JsonDeserialize<PhoInfo>(result);
        }

        /// <summary>
        /// 取消喜欢照片
        /// </summary>
        /// <param name="id">照片id</param>
        public static void PhoDeleteLike(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.PHOLIKEOP_ID, id));
        }

        /// <summary>
        /// 获取回复列表
        /// </summary>
        /// <param name="id">照片id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>回复搜索结果</returns>
        public static CommSearch PhoGetComments(string id, int? start = null, int? count = null)
        {
            return CommGetComments(Common.PHOCOMMENTSOP_ID, id, start, count);
        }

        /// <summary>
        /// 新发回复
        /// </summary>
        /// <param name="id">照片id</param>
        /// <param name="content">回复内容</param>
        /// <returns>回复信息</returns>
        public static CommInfo PhoPostComment(string id, string content)
        {
            return CommPostComment(Common.PHOCOMMENTSOP_ID, id, content);
        }

        /// <summary>
        /// 获取单条回复
        /// </summary>
        /// <param name="noteId">照片id</param>
        /// <param name="commentId">回复id</param>
        /// <returns>回复信息</returns>
        public static CommInfo PhoGetComment(string photoId, string commentId)
        {
            return CommGetComment(Common.PHOCOMMENTOP_ID, photoId, commentId);
        }

        /// <summary>
        /// 删除回复
        /// </summary>
        /// <param name="noteId">照片id</param>
        /// <param name="commentId">回复id</param>
        public static void PhoDeleteComment(string photoId, string commentId)
        {
            CommDeleteComment(Common.PHOCOMMENTOP_ID, photoId, commentId);
        }
    }
}