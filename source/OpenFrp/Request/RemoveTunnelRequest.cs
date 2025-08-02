using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Request
{
    /// <summary>
    /// 删除隧道
    /// </summary>
    public class RemoveTunnelRequest
    {
        [JsonPropertyName("proxy_id")]
        public int Id { get; set; }
    }
}
