using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 获取access_token返回值
    /// </summary>
    public class AuthAccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; private set; }
        [JsonProperty("expires_in")]
        public int Expired { get; private set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }
        [JsonProperty("douban_user_id")]
        public string UserId { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取authorization_code
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="scope">(可选)申请权限的范围</param>
        /// <returns>authorization_code</returns>
        public static string AuthGetCode(string name, string pwd, string scope = null)
        {
            UriBuilder ub = new UriBuilder(Common.AUTHGETCODE);
            Utilities.AddParam(ref ub, "client_id", Common.APIKey);
            Utilities.AddParam(ref ub, "redirect_uri", Common.RedirectUri);
            Utilities.AddParam(ref ub, "response_type", Common.RESPONSETYPE);
            Utilities.AddParam(ref ub, "scope", scope);
            StringBuilder builder = new StringBuilder();
            builder.Append("user_email", name);
            builder.Append("user_passwd", pwd);
            builder.Append("confirm", "授权");
            using (HttpWebResponse res = Utilities.GetResponse(ub.ToString(), builder.ToString()))
            {
                int start = res.ResponseUri.Query.LastIndexOf("=");
                Common.AuthCode = res.ResponseUri.Query.Substring(start + 1);
                return Common.AuthCode;
            }
        }

        /// <summary>
        /// 获得Token
        /// </summary>
        /// <returns>AccessToken</returns>
        public static AuthAccessToken AuthGetToken()
        {
            UriBuilder ub = new UriBuilder(Common.AUTHTOKENOP);
            Utilities.AddParam(ref ub, "client_id", Common.APIKey);
            Utilities.AddParam(ref ub, "client_secret", Common.Secret);
            Utilities.AddParam(ref ub, "redirect_uri", Common.RedirectUri);
            Utilities.AddParam(ref ub, "grant_type", Common.GRANTTYPE_GETCODE);
            Utilities.AddParam(ref ub, "code", Common.AuthCode);
            string result = Utilities.RequestPost(ub.ToString());
            AuthAccessToken token = (AuthAccessToken)Utilities.JsonDeserialize<AuthAccessToken>(result);
            Common.Token = token.Token;
            Common.RefreshToken = token.RefreshToken;
            Common.UserId = token.UserId;
            return token;
        }

        /// <summary>
        /// 更换Token
        /// </summary>
        /// <returns>AccessToken</returns>
        public static AuthAccessToken AuthRefreshToken()
        {
            UriBuilder ub = new UriBuilder(Common.AUTHTOKENOP);
            Utilities.AddParam(ref ub, "client_id", Common.APIKey);
            Utilities.AddParam(ref ub, "client_secret", Common.Secret);
            Utilities.AddParam(ref ub, "redirect_uri", Common.RedirectUri);
            Utilities.AddParam(ref ub, "grant_type", Common.GRANTTYPE_REFRESH);
            Utilities.AddParam(ref ub, "refresh_token", Common.RefreshToken);
            string result = Utilities.RequestPost(ub.ToString());
            AuthAccessToken token = (AuthAccessToken)Utilities.JsonDeserialize<AuthAccessToken>(result);
            Common.Token = token.Token;
            Common.RefreshToken = token.RefreshToken;
            return token;
        }
    }
}
