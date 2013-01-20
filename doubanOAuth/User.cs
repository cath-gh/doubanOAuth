using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace doubanOAuth
{
    /// <summary>
    /// 用户完整版信息
    /// </summary>
    public class UsrInfo
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("uid")]
        public string Uid { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("avatar")]
        public string Avatar { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("relation")]
        public string Relation { get; private set; }
        [JsonProperty("signature")]
        public string Signature { get; private set; }
        [JsonProperty("created")]
        public string Created { get; private set; }
        [JsonProperty("loc_id")]
        public string LocId { get; private set; }
        [JsonProperty("loc_name")]
        public string LocName { get; private set; }
        [JsonProperty("desc")]
        public string Desc { get; private set; }
    }

    /// <summary>
    /// 用户简版
    /// </summary>
    public class UsrSimple
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("uid")]
        public string Uid { get; private set; }
        [JsonProperty("alt")]
        public string Alt { get; private set; }
        [JsonProperty("avatar")]
        public string Avatar { get; private set; }
    }

    /// <summary>
    /// 用户搜索结果
    /// </summary>
    public class UsrSearch : SearchResult
    {
        [JsonProperty("users")]
        public List<UsrSimple> Users { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="name">用户uid或者数字id</param>
        /// <returns>用户完整版信息</returns>
        public static UsrInfo UsrGetUser(string name)
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.USRINFO, name));
            return (UsrInfo)Utilities.JsonDeserialize<UsrInfo>(result);
        }

        /// <summary>
        /// 获取当前授权用户信息
        /// </summary>
        /// <returns>用户简版</returns>
        public static UsrInfo UsrGetMe()
        {
            string result = Utilities.RequestGet(Utilities.CreateUrl(Common.USRME), true);
            return (UsrInfo)Utilities.JsonDeserialize<UsrInfo>(result);
        }

        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>用户搜索结果</returns>
        public static UsrSearch UsrSearch(string keyword, int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.USRSEARCH);
            Utilities.AddParam(ref ub, "q", keyword);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString());
            return (UsrSearch)Utilities.JsonDeserialize<UsrSearch>(result);
        }
    }
}
