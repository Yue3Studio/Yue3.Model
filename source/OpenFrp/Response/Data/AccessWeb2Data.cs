using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    public class AccessWeb2Data
    {
        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("authorization_data")]
        public string? AuthorizationData { get; set; }

        [JsonPropertyName("authorization_url")]
        public string? AuthorizeUrl { get; set; }

        /// <summary>
        /// 请求 ID
        /// </summary>
        [JsonPropertyName("request_uuid")]
        public string? GuidString { get; set; }
    }
}
