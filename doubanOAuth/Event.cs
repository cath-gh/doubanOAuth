using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 活动信息
    /// </summary>
    public class EvtInfo
    {
        [JsonProperty("is_priv")]
        public string IsPriv { get; private set; }
        [JsonProperty("participant_count")]
        public int ParticipantCount { get; private set; }
        [JsonProperty("image")]
        public string Image { get; private set; }
        [JsonProperty("adapt_url")]
        public string AdaptUrl { get; private set; }
        [JsonProperty("begin_time")]
        public string BeginTime { get; private set; }
        [JsonProperty("owner")]
        public UsrSimple Owner { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("geo")]
        public string Geo { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("album")]
        public string Album { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("wisher_count")]
        public int WisherCount { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
        [JsonProperty("image-hlarge")]
        public string ImageHLarge { get; private set; }
        [JsonProperty("end_time")]
        public string EndTime { get; private set; }
        [JsonProperty("image-lmobile")]
        public string ImageLMobile { get; private set; }
        [JsonProperty("has_invited")]
        public string HasInvited { get; private set; }
        [JsonProperty("can_invite")]
        public string CanInvite { get; private set; }
        [JsonProperty("address")]
        public string Address { get; private set; }
        [JsonProperty("loc_name")]
        public string LocName { get; private set; }
        [JsonProperty("loc_id")]
        public string LocId { get; private set; }
    }

    /// <summary>
    /// 活动搜索结果
    /// </summary>
    public class EvtSearch : SearchResult
    {
        [JsonProperty("events")]
        public List<EvtInfo> Events { get; private set; }
    }

    /// <summary>
    /// 城市信息
    /// </summary>
    public class EvtCity
    {
        [JsonProperty("parent")]
        public string Parent { get; private set; }
        [JsonProperty("habitable")]
        public string Habitable { get; private set; }
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("uid")]
        public string Uid { get; private set; }
    }

    /// <summary>
    /// 城市搜索结果
    /// </summary>
    public class EvtCitySearch : SearchResult
    {
        [JsonProperty("locs")]
        public List<EvtCity> Locs { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <returns>活动信息</returns>
        public static EvtInfo EvtGetEvent(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.EVTINFO_ID, id));
            return (EvtInfo)Utilities.JsonDeserialize<EvtInfo>(result);
        }

        /// <summary>
        /// 获取参加活动的用户
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>用户搜索结果</returns>
        public static UsrSearch EvtGetPartUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTPARTUSERS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (UsrSearch)Utilities.JsonDeserialize<UsrSearch>(result);
        }

        /// <summary>
        /// 获取感兴趣活动的用户
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>用户搜索结果</returns>
        public static UsrSearch EvtGetWishUsers(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTWISHUSERS_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (UsrSearch)Utilities.JsonDeserialize<UsrSearch>(result);
        }

        /// <summary>
        /// 获取用户创建的活动
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>活动搜索结果</returns>
        public static EvtSearch EvtGetUserCreate(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTUSERCREATE_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (EvtSearch)Utilities.JsonDeserialize<EvtSearch>(result);
        }

        /// <summary>
        /// 获取用户参加的活动
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>活动搜索结果</returns>
        public static EvtSearch EvtGetUserPart(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTUSERPART_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (EvtSearch)Utilities.JsonDeserialize<EvtSearch>(result);
        }

        /// <summary>
        /// 获取用户感兴趣的活动
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>活动搜索结果</returns>
        public static EvtSearch EvtGetUserWish(string id, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTUSERWISH_ID, id);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (EvtSearch)Utilities.JsonDeserialize<EvtSearch>(result);
        }

        /// <summary>
        /// 活动搜索
        /// </summary>
        /// <param name="id">城市id</param>
        /// <param name="dayType">时间类型(future, week, weekend, today, tomorrow)</param>
        /// <param name="type">活动类型(all, music, film, drama, commonweal, salon, exhibition, party, sports, travel, others)</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>活动搜索结果</returns>
        public static EvtSearch EvtSearch(string id, string dayType, string type, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTLIST);
            Utilities.AddParam(ref ub, "loc", id);
            Utilities.AddParam(ref ub, "day_type", dayType);
            Utilities.AddParam(ref ub, "type", type);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (EvtSearch)Utilities.JsonDeserialize<EvtSearch>(result);
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="id">城市id</param>
        /// <returns>城市信息</returns>
        public static EvtCity EvtGetCity(string id)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.EVTCITY_ID, id));
            return (EvtCity)Utilities.JsonDeserialize<EvtCity>(result);
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns></returns>
        public static EvtCitySearch EvtGetCities(int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.EVTCITIES);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (EvtCitySearch)Utilities.JsonDeserialize<EvtCitySearch>(result);
        }

        /// <summary>
        /// 参加活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="participateDate">参加时间(时间格式: "％Y-％m-％d", 无此参数则时间待定)</param>
        public static void EvtPostPart(string id, string participateDate)
        {
            string url = Utilities.CreateUrl(Common.EVTPARTOP_ID, id);
            StringBuilder builder = new StringBuilder();
            builder.Append("participate_date", participateDate);
            Utilities.RequestPost(url, builder.ToString());
        }

        /// <summary>
        /// 不参加活动
        /// </summary>
        /// <param name="id">活动id</param>
        public static void EvtDeletePart(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.EVTPARTOP_ID, id));
        }

        /// <summary>
        /// 对活动感兴趣
        /// </summary>
        /// <param name="id">活动id</param>
        public static void EvtPostWish(string id)
        {
            Utilities.RequestPost(Utilities.CreateUrl(Common.EVTWISHOP_ID, id));
        }

        /// <summary>
        /// 对活动不感兴趣
        /// </summary>
        /// <param name="id">活动id</param>
        public static void EvtDeleteWish(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.EVTWISHOP_ID, id));
        }
    }
}