using Newtonsoft.Json;
using System;

namespace doubanOAuth
{
    public static class Common
    {
        #region Pool
        public static Error LastError { get; set; }
        public static string APIKey { get; set; }
        public static string Secret { get; set; }
        public static string RedirectUri { get; set; }
        public static string AuthCode { get; set; }
        public static string Token { get; set; }
        public static string RefreshToken { get; set; }
        public static string AuthHeader { get { return String.Concat("Authorization: Bearer ", Token); } }
        public static string UserId { get; set; }
        public static int SingleUserRemain { get; set; }
        public static int SingleIPRemain { get; set; } 
        #endregion

        #region HttpWebRequest
        internal const string ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        internal const string CONTENTTYPE = "application/x-www-form-urlencoded";
        internal const string USERAGGENT = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11";
        internal const string REFERER = "http://www.douban.com/";
        internal const string REFERER_SELF = "http://cath.dnip.net/";
        #endregion

        #region UriBuilder
        internal const string SCHEME = "https";
        internal const string HOST = "api.douban.com";
        internal const int PORT = 443;
        #endregion

        #region Authenticate
        internal const string AUTHGETCODE = "https://www.douban.com/service/auth2/auth";
        internal const string AUTHTOKENOP = "https://www.douban.com/service/auth2/token";
        internal const string RESPONSETYPE = "code";
        internal const string GRANTTYPE_GETCODE = "authorization_code";
        internal const string GRANTTYPE_REFRESH = "refresh_token";
        #endregion

        #region User
        internal const string USRINFO = "/v2/user/:name";
        internal const string USRME = "/v2/user/~me";
        internal const string USRSEARCH = "/v2/user";
        #endregion

        #region Book
        internal const string BKINFO_ID = "/v2/book/:id";
        internal const string BKINFO_NAME = "/v2/book/isbn/:name";
        internal const string BKSEARCH = "/v2/book/search";
        internal const string BKTOPTAGS_ID = "/v2/book/:id/tags";
        internal const string BKUSERTAGS_NAME = "/v2/book/user/:name/tags";
        internal const string BKUSERCOLS_NAME = "/v2/book/user/:name/collections";
        internal const string BKUSERCOL_ID = "/v2/book/:id/collection";
        internal const string BKUSERANNOS_NAME = "/v2/book/user/:name/annotations";
        internal const string BKANNOS_ID = "/v2/book/:id/annotations";
        internal const string BKANNO_ID = "/v2/book/annotation/:id";

        internal const string BKCOLOP_ID = "/v2/book/:id/collection";
        internal const string BKPOSTANNO_ID = "/v2/book/:id/annotations";
        internal const string BKANNOOP_ID = "/v2/book/annotation/:id";

        internal const string BKPOSTREVIEW = "/v2/book/reviews";
        internal const string BKREVIEWOP_ID = "/v2/book/review/:id";
        #endregion

        #region Movie
        internal const string MOVINFO_ID = "/v2/movie/:id";
        internal const string MOVINFO_IMDB = "/v2/movie/imdb/:name";
        internal const string MOVSEARCH = "/v2/movie/search";
        internal const string MOVTOPTAGS_ID = "/v2/movie/:id/tags";

        internal const string MOVPOSTREVIEW = "/v2/movie/reviews";
        internal const string MOVREVIEWOP_ID = "/v2/movie/review/:id";
        internal const string MOVUSERTAGS_ID = "/v2/movie/user_tags/:id";
        #endregion

        #region Music
        internal const string MUSINFO_ID = "/v2/music/:id";
        internal const string MUSSEARCH = "/v2/music/search";
        internal const string MUSTOPTAGS_ID = "/v2/music/:id/tags";

        internal const string MUSPOSTREVIEW = "/v2/music/reviews";
        internal const string MUSREVIEWOP_ID = "/v2/music/review/:id";
        internal const string MUSUSERTAGS_ID = "/v2/music/user_tags/:id";
        #endregion

        #region Event
        internal const string EVTINFO_ID = "/v2/event/:id";
        internal const string EVTPARTUSERS_ID = "/v2/event/:id/participants";
        internal const string EVTWISHUSERS_ID = "/v2/event/:id/wishers";
        internal const string EVTUSERCREATE_ID = "/v2/event/user_created/:id";
        internal const string EVTUSERPART_ID = "/v2/event/user_participated/:id";
        internal const string EVTUSERWISH_ID = "/v2/event/user_wished/:id";
        internal const string EVTLIST = "/v2/event/list";
        internal const string EVTCITY_ID = "/v2/loc/:id";
        internal const string EVTCITIES = "/v2/loc/list";

        internal const string EVTPARTOP_ID = "/v2/event/:id/participants";
        internal const string EVTWISHOP_ID = "/v2/event/:id/wishers";
        #endregion

        #region Shuo
        internal const string SHUOPOST = "shuo/v2/statuses/";
        internal const string SHUOHOMESHUOS = "shuo/v2/statuses/home_timeline";
        internal const string SHUOUSERSHUOS_ID = "shuo/v2/statuses/user_timeline/:id";
        internal const string SHUOOP_ID = "shuo/v2/statuses/:id";
        internal const string SHUOCOMMENTSOP_ID = "shuo/v2/statuses/:id/comments";
        internal const string SHUOCOMMENTOP_ID = "shuo/v2/statuses/comment/:id";
        internal const string SHUORESHAREOP_ID = "shuo/v2/statuses/:id/reshare";
        internal const string SHUOLIKEOP_ID = "shuo/v2/statuses/:id/like";

        internal const string SHUOUSERFOLLOWS_ID = "shuo/v2/users/:id/following";
        internal const string SHUOFOLLOWUSERS_ID = "shuo/v2/users/:id/followers";
        internal const string SHUOFOLLOWINCOMMONS_ID = "shuo/v2/users/:id/follow_in_common";
        internal const string SHUOUSERINFOLLOWS_ID = "shuo/v2/users/:id/following_followers_of";
        internal const string SHUOSEARCHUSERS = "shuo/v2/users/search";
        internal const string SHUOBLOCKUSER_ID = "shuo/v2/users/:id/block";

        internal const string SHUOPOSTFOLLOW = "shuo/v2/friendships/create";
        internal const string SHUODELETEFOLLOW = "shuo/v2/friendships/destroy";
        internal const string SHUOFRIENDSHIP = "shuo/v2/friendships/show";
        #endregion

        #region Mail
        internal static string MAILINFO_ID = "/v2/doumail/:id";
        internal static string MAILINBOX = "/v2/doumail/inbox";
        internal static string MAILOUTBOX = "/v2/doumail/outbox";
        internal static string MAILUNREAD = "/v2/doumail/inbox/unread";

        internal static string MAILPOSTMAIL = "/v2/doumails";
        internal static string MAILMARKREAD_ID = "/v2/doumail/:id";
        internal static string MAILMARKREAD = "/v2/doumail/read";
        internal static string MAILDELETEMAIL_ID = "/v2/doumail/:id";
        internal static string MAILDELETEMAILS = "/v2/doumail/delete";
        #endregion

        #region Note
        internal static string NOTEPOSTNOTE = "/v2/notes";
        internal static string NOTEOP_ID = "/v2/note/:id";
        internal static string NOTELIKEOP_ID = "/v2/note/:id/like";
        internal static string NOTEUSERCREATES_ID = "/v2/note/user_created/:id";
        internal static string NOTEUSERLIKES_ID = "/v2/note/user_liked/:id";
        internal static string NOTEUSERGUESSES_ID = "/v2/note/people_notes/:id/guesses";

        internal static string NOTECOMMENTSOP_ID = "/v2/note/:id/comments";
        internal static string NOTECOMMENTOP_ID = "/v2/note/:id1/comment/:id2";
        #endregion

        #region Photo
        internal static string PHOALBUMOP_ID = "/v2/album/:id";
        internal static string PHOLIST_ID = "/v2/album/:id/photos";
        internal static string PHOOP_ID = "/v2/photo/:id";
        internal static string PHOCOMMENTSOP_ID = "/v2/photo/:id/comments";
        internal static string PHOCOMMENTOP_ID = "/v2/photo/:id1/comment/:id2";

        internal static string PHOCREATEALBUM = "/v2/albums";
        internal static string PHOALBUMLIKEOP_ID = "/v2/album/:id/like";
        internal static string PHOLIKEOP_ID = "/v2/photo/:id/like";
        internal static string PHOUSERCREATEALBS_ID = "/v2/album/user_created/:id";
        internal static string PHOUSERLIKEALBS_ID = "/v2/album/user_liked/:id";
        #endregion

        #region Online
        internal static string ONLOP_ID = "/v2/online/:id";
        internal static string ONLPARTOP_ID = "/v2/online/:id/participants";
        internal static string ONLDISCOP_ID = "/v2/online/:id/discussions";
        internal static string ONLLISTOP = "/v2/onlines";

        internal static string ONLLIKEOP_ID = "/v2/online/:id/like";
        internal static string ONLPHOTOOP_ID = "/v2/online/:id/photos";
        internal static string ONLUSERPARTS_ID = "/v2/online/user_participated/:id";
        internal static string ONLUSERCREATES_ID = "/v2/online/user_created/:id";
        #endregion

        #region Discussion
        internal static string DISCOP_ID = "/v2/discussion/:id";
        internal static string DISCCOMMENTSOP_ID = "/v2/discussion/:id/comments";
        internal static string DISCCOMMENTOP_ID = "/v2/discussion/:id1/comment/:id2";
        #endregion
    }

    /// <summary>
    /// 搜索结果
    /// </summary>
    public abstract class SearchResult
    {
        [JsonProperty("count")]
        internal int Count { get; private set; }
        [JsonProperty("start")]
        internal int Start { get; private set; }
        [JsonProperty("total")]
        internal int Total { get; private set; }
    }

    /// <summary>
    /// 评分
    /// </summary>
    public class Rating
    {
        [JsonProperty("max")]
        internal int Max { get; private set; }
        [JsonProperty("min")]
        internal int Min { get; private set; }
        [JsonProperty("value")]
        internal string Value { get; private set; }
    }

    /// <summary>
    /// 整体评分
    /// </summary>
    public class RatingItem
    {
        [JsonProperty("max")]
        internal int Max { get; private set; }
        [JsonProperty("numRaters")]
        internal int NumRaters { get; private set; }
        [JsonProperty("average")]
        internal string Average { get; private set; }
        [JsonProperty("min")]
        internal int Min { get; private set; }
    }

    /// <summary>
    /// 作者
    /// </summary>
    public class Author
    {
        [JsonProperty("name")]
        internal string Name { get; private set; }
    }
}
