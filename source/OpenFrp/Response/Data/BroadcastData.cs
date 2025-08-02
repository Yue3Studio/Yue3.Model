using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    public class BroadcastData
    {
        public BroadcastData() { }

        public class AlertItem
        {
            /// <summary>
            /// 标题
            /// </summary>
            [JsonPropertyName("title")]
            public string Title { get; set; } = "";

            /// <summary>
            /// 类型（消息类型，不是内容类型）
            /// </summary>
            [JsonPropertyName("type")]
            public string Type { get; set; } = "";

            /// <summary>
            /// 内容（每一个对象对应着一行）
            /// </summary>
            [JsonPropertyName("data")]
            public string[] Data { get; set; } = Array.Empty<string>();

            /// <summary>
            /// 最大版本 - 显示内容
            /// </summary>
            [JsonPropertyName("maximumVersion")]
            public int MaximumVersion { get; set; } = -1;

            /// <summary>
            /// 最小版本 - 显示内容
            /// </summary>
            [JsonPropertyName("minimalVersion")]
            public int MinimalVersion { get; set; } = -1;
        }

        [JsonPropertyName("alerts")]
        public AlertItem[] Alerts { get; set; } = Array.Empty<AlertItem>();
    }
}
