using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace doubanOAuth
{
    /// <summary>
    /// 错误信息
    /// </summary>
    public class Error
    {
        #region Properties
        [JsonProperty("msg")]
        public string Message { get; private set; }
        [JsonProperty("code")]
        public int Code { get; private set; }
        [JsonProperty("request")]
        public string Request { get; private set; }
        public DateTime Date { get; private set; }
        public string Url { get; private set; }
        public string Status { get; private set; }
        #endregion

        #region Constructors
        public Error()
        { }

        public Error(WebException e)
        {
            Error error = new Error();
            this.Date = DateTime.Now;
            this.Url = e.Response.ResponseUri.AbsoluteUri;
            this.Status = e.Message;
            using (StreamReader sr = new StreamReader(e.Response.GetResponseStream(), Encoding.UTF8))
                error = (Error)Utilities.JsonDeserialize<Error>(sr.ReadToEnd());
            this.Message = error.Message;
            this.Code = error.Code;
            this.Request = error.Request;
        }
        #endregion
    }
}
