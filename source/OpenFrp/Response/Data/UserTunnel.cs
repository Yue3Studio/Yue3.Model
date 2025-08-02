using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    /// <summary>
    /// 用户隧道数据
    /// </summary>
    public class UserTunnelData : CollectionData<UserTunnel>
    {

    }

    /// <summary>
    /// 用户隧道 (If you need to post edit/new, pls Use another...)
    /// </summary>
    public class UserTunnel : ICloneable
    {
        /// <summary>
        /// 隧道 ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// 隧道名称
        /// </summary>
        [JsonPropertyName("proxyName")]
        public string? Name { get; set; }

        /// <summary>
        /// 隧道类型
        /// </summary>
        [JsonPropertyName("proxyType")]
        public string? Type
        {
            get => type?.ToUpper();
            set
            {
                type = value?.ToLower();
            }
        }

        private string? type;

        /// <summary>
        /// 本地链接
        /// </summary>
        [JsonPropertyName("localIp")]
        public string? Host { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        [JsonPropertyName("localPort")]
        public ushort Port { get; set; }

        /// <summary>
        /// 远程端口
        /// </summary>
        [JsonPropertyName("remotePort")]
        public int RemotePort { get; set; } = 0;

        /// <summary>
        /// 节点 ID
        /// </summary>
        [JsonPropertyName("nid")]
        public int NodeId { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [JsonPropertyName("friendlyNode")]
        public string? NodeName { get; set; }

        ///// <summary>
        ///// 上次更新时间
        ///// </summary>
        //[JsonPropertyName("lastUpdate")]
        //public long LastUpdate { get; set; }

        /// <summary>
        /// 使用数据加密
        /// </summary>
        [JsonPropertyName("useEncryption")]
        public bool UseEncryption { get; set; }

        /// <summary>
        /// 使用数据压缩
        /// </summary>
        [JsonPropertyName("useCompression")]
        public bool UseCompression { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [JsonPropertyName("connectAddress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ConnectAddress { get; set; }

        /// <summary>
        /// 扩展地址
        /// </summary>
        [JsonPropertyName("extAddress")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] ExtraConnectAddress { get; set; } = Array.Empty<string>();

        /// <inheritdoc/>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <inheritdoc cref="Clone"/>
        public UserTunnel CloneUserTunnel()
        {
            return (UserTunnel)Clone();
        }

        /// <summary>
        /// 域名列表 (JSON)
        /// </summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? DomainsJsonString { get; set; }

        /// <summary>
        /// 域名列表
        /// </summary>
        [JsonIgnore]
        public HashSet<string> Domains
        {
            get
            {
                if (!string.IsNullOrEmpty(DomainsJsonString))
                {
                    try
                    {
                        return System.Text.Json.JsonSerializer.Deserialize<HashSet<string>>(DomainsJsonString!) ?? new HashSet<string>();
                    }
                    catch
                    {

                    }
                }
                return new();
            }
            set
            {
                if (value is null)
                {
                    DomainsJsonString = "";
                    return;
                }
                DomainsJsonString = System.Text.Json.JsonSerializer.Serialize(value);
            }
        }

        /// <summary>
        /// HAProxy的proxyProtocolVersion选项(默认为V2)
        /// </summary>
        [JsonPropertyName("proxyProtocolVersion")]
        public bool ProxyProtocolVersion2 { get; set; }
        ///// <summary>
        ///// URL 路由
        ///// </summary>
        //[JsonPropertyName("url_route")]
        //public string? URLRoute { get; set; }

        /// <summary>
        /// 隧道自定义配置
        /// </summary>
        [JsonPropertyName("custom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? TunnelCustomConfig { get; set; }

        /// <summary>
        /// 是否允许使用
        /// </summary>
        [JsonPropertyName("status")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        [JsonPropertyName("online")]
        public bool IsOnline { get; set; }

    }
}
