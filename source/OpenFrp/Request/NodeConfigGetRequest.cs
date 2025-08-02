using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Request
{
    /// <summary>
    /// 获取配置
    /// </summary>
    public class NodeConfigGetRequest
    {
        [JsonPropertyName("node_id")]
        public int NodeId { get; set; }
    }
}
