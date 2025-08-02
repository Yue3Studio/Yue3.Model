using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Request
{
    /// <summary>
    /// 创建 / 修改隧道
    /// </summary>
    public class ModifyTunnelRequest
    {
        public ModifyTunnelRequest() { }

        public ModifyTunnelRequest(Model.OpenFrp.Response.Data.UserTunnel tunnel)
        {
            var tft = tunnel.GetType();
            var properties = typeof(ModifyTunnelRequest).GetProperties();

            foreach (var item in properties)
            {
                if (item.CanWrite && item.CanRead)
                {
                    if (tft.GetProperty(item.Name) is { } pr)
                    {
                        item.SetValue(this, pr.GetValue(tunnel));
                    }
                }
            }
        }

        /// <summary>
        /// 使用数据加密
        /// </summary>
        [JsonPropertyName("dataEncrypt")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool UseEncryption { get; set; }

        /// <summary>
        /// 使用数据压缩
        /// </summary>
        [JsonPropertyName("dataGzip")]
        //d[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool UseCompression { get; set; }

        /// <summary>
        /// 强制 Https
        /// </summary>
        [JsonPropertyName("forceHttps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ForceHttps
        {
            get
            {
                if (type is not null && type.Contains("http"))
                {
                    return forceHttps;
                }
                return false;
            }
            set
            {
                if (type is not null && type.Contains("http"))
                {
                    forceHttps = value;
                }
            }
        }

        private bool forceHttps;

        /// <summary>
        /// 本地链接
        /// </summary>
        [JsonPropertyName("local_addr")]
        public string? Host { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        [JsonPropertyName("local_port")]
        public int Port { get; set; }


        /// <summary>
        /// 远程端口
        /// </summary>
        [JsonPropertyName("remote_port")]
        public int? RemotePort { get; set; } = -1;

        /// <summary>
        /// HAProxy的proxyProtocolVersion选项(默认为V2)
        /// </summary>
        [JsonPropertyName("proxyProtocolVersion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ProxyProtocolVersionV2 { get; set; }

        /// <summary>
        /// 隧道类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get => type ?? "tcp";
            set
            {
                type = value.ToLower();
            }
        }

        private string? type;

        /// <summary>
        /// 隧道类型
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("proxy_id")]
        public int? Id { get; set; }

        /// <summary>
        /// 隧道名称
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 节点 ID (创建时候传入 -1)
        /// </summary>
        [JsonPropertyName("node_id")]
        public int NodeId { get; set; } = -1;

        /// <summary>
        /// 隧道自定义配置
        /// </summary>
        [JsonPropertyName("custom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? TunnelCustomConfig { get; set; }

        /// <summary>
        /// 域名列表 (JSON)
        /// </summary>
        [JsonPropertyName("domain_bind")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? DomainsJsonString { get; set; }
    }
}
