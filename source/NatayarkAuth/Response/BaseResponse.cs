using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
namespace Yue3.Model.NatayarkAuth.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// 消息
        /// </summary>
        [JsonPropertyName("msg")]
        public string? Message { get; set; }

        /// <summary>
        /// HTTP 状态码
        /// </summary>
        [JsonPropertyName("code")]
        public HttpStatusCode Code { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        /// <summary>
        /// 数据内容
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
