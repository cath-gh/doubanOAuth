using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 豆邮信息
    /// </summary>
    public class MailInfo
    {
        [JsonProperty("status")]
        public string Status{get;private set;}
        [JsonProperty("id")]
        public string Id { get; private set; }
        [JsonProperty("sender")]
        public UsrSimple Sender { get; private set; }
        [JsonProperty("receiver")]
        public UsrSimple Receiver { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("published")]
        public string Published { get; private set; }
        [JsonProperty("content")]
        public string Content { get; private set; }
    }

    /// <summary>
    /// 邮件搜索结果
    /// </summary>
    public class MailSearch : SearchResult
    {
        [JsonProperty("mails")]
        public List<MailInfo> Mails { get; private set; }
    }

    public static partial class API
    {
        /// <summary>
        /// 获取一封豆邮
        /// </summary>
        /// <param name="id">邮件id</param>
        /// <param name="keepUnread">(可选)是否保持未读状态</param>
        /// <returns>豆邮信息</returns>
        public static MailInfo MailGetMail(string id, bool? keepUnread = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MAILINFO_ID, id);
            Utilities.AddParam(ref ub, "keep_unread", keepUnread);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (MailInfo)Utilities.JsonDeserialize<MailInfo>(result);
        }

        /// <summary>
        /// 获取用户收件箱
        /// </summary>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>邮件搜索结果</returns>
        public static MailSearch MailGetInbox(int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MAILINBOX);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (MailSearch)Utilities.JsonDeserialize<MailSearch>(result);
        }

        /// <summary>
        /// 获取用户发件箱
        /// </summary>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>邮件搜索结果</returns>
        public static MailSearch MailGetOutbox(int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MAILOUTBOX);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (MailSearch)Utilities.JsonDeserialize<MailSearch>(result);
        }

        /// <summary>
        /// 获取用户未读邮件
        /// </summary>
        /// <param name="start">(可选)取结果的offset</param>
        /// <param name="count">(可选)取结果的条数(默认为20, 最大为100)</param>
        /// <returns>邮件搜索结果</returns>
        public static MailSearch MailGetUnread(int? start = null, int? count = null)
        {
            UriBuilder ub = Utilities.CreateUB(Common.MAILUNREAD);
            Utilities.AddParam(ref ub, "start", start);
            Utilities.AddParam(ref ub, "count", count);
            string result = Utilities.RequestGet(ub.ToString(), true);
            return (MailSearch)Utilities.JsonDeserialize<MailSearch>(result);
        }

        /// <summary>
        /// 标记已读一封邮件
        /// </summary>
        /// <param name="id">豆邮id</param>
        /// <returns>豆邮信息</returns>
        public static MailInfo MailMarkRead(string id)
        {
            string result = Utilities.RequestPut(Utilities.CreateUrl(Common.MAILMARKREAD_ID, id));
            return (MailInfo)Utilities.JsonDeserialize<MailInfo>(result);
        }

        /// <summary>
        /// 批量标记豆邮为已读
        /// </summary>
        /// <param name="ids">需要标记为已读的豆邮id(以','分割)</param>
        /// <returns>邮件搜索结果</returns>
        public static MailSearch MailMarkReadBatch(string ids)
        {
            string url = Utilities.CreateUrl(Common.MAILMARKREAD);
            StringBuilder builder = new StringBuilder();
            builder.Append("ids", ids);
            string result = Utilities.RequestPut(url, builder.ToString());
            return (MailSearch)Utilities.JsonDeserialize<MailSearch>(result);
        }

        /// <summary>
        /// 删除一封豆邮
        /// </summary>
        /// <param name="id">豆邮id</param>
        public static void MailDeleteMail(string id)
        {
            Utilities.RequestDelete(Utilities.CreateUrl(Common.MAILDELETEMAIL_ID, id));
        }

        /// <summary>
        /// 批量删除豆邮
        /// </summary>
        /// <param name="ids">需要删除的豆邮id(以','分割)</param>
        public static void MailDeleteMailBatch(string ids)
        {
            string url = Utilities.CreateUrl(Common.MAILDELETEMAILS);
            StringBuilder builder = new StringBuilder();
            builder.Append("ids", ids);
            Utilities.RequestPost(url, builder.ToString());
        }

        /// <summary>
        /// 发送一封豆邮(验证部分未作)
        /// </summary>
        /// <param name="title">豆邮标题</param>
        /// <param name="content">豆邮正文</param>
        /// <param name="receiverId">接收邮件的用户id</param>
        /// <param name="captchaToken">(可选)系统验证码token</param>
        /// <param name="captchaString">(可选)用户输入验证码</param>
        /// <returns>豆邮信息</returns>
        public static MailInfo MailPostMail(string title, string content, string receiverId, string captchaToken = null, string captchaString = null)
        {
            string url = Utilities.CreateUrl(Common.MAILPOSTMAIL);
            StringBuilder builder = new StringBuilder();
            builder.Append("title", title);
            builder.Append("content", content);
            builder.Append("receiver_id", receiverId);
            builder.Append("captcha_token", captchaToken);
            builder.Append("captcha_string", captchaString);
            string result = Utilities.RequestPost(url, builder.ToString());
            return (MailInfo)Utilities.JsonDeserialize<MailInfo>(result);
        }
    }
}
