using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response
{
    public class BaseResponse2
    {
        /// <summary>
        /// 消息
        /// </summary>
        [JsonPropertyName("msg")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        /// <summary>
        /// HTTP 状态码
        /// </summary>
        [JsonPropertyName("code")]
        public HttpStatusCode Code { get; set; }
    }

    public class BaseResponse2<T> : BaseResponse2
    {
        /// <summary>
        /// 数据内容
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
