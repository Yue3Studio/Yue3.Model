using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    public class NodeData : CollectionData<Node>
    {

    }

    public class Node : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 节点宽带
        /// </summary>
        [JsonPropertyName("bandwidth")]
        public int BandWidth { get; set; }

        /// <summary>
        /// 节点宽带倍率
        /// </summary>
        [JsonPropertyName("bandwidthMagnification")]
        public double BandWidthScale { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        [JsonPropertyName("classify")]
        public NodeClassify Classify { get; set; }

        /// <summary>
        /// 节点 ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 是否需要实名
        /// </summary>
        [JsonPropertyName("needRealname")]
        public bool NeedRealname { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 是否满载
        /// </summary>
        [JsonPropertyName("fullyLoaded")]
        public bool IsFullyLoaded { get; set; }

        /// <summary>
        /// 允许的端口范围
        /// </summary>
        [JsonPropertyName("allowPort")]
        public string? AllowPortRangeString { get; set; }

        /// <summary>
        /// 允许的端口范围
        /// </summary>
        public NodePortRange AllowPortRange
        {
            get => AllowPortRangeString;
        }

        /// <summary>
        /// 组限制
        /// </summary>
        [JsonPropertyName("group")]
        public string? Group { get; set; }



        /// <summary>
        /// 支持的协议类型
        /// </summary>
        [JsonPropertyName("protocolSupport")]
        public NodeProtocolSupport? ProtocolSupport { get; set; }

        /// <summary>
        /// 类型限制(友好名称)
        /// </summary>
        [JsonIgnore]
        public string FriendlyWebProtocolSupport
        {
            get
            {
                if (ProtocolSupport is { } val)
                {
                    if (val.HTTPS)
                    {
                        if (val.HTTP) return "HTTP(S)";
                        return "HTTPS";
                    }
                    else if (val.HTTP)
                    {
                        return "HTTP";
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonPropertyName("status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// 记述
        /// </summary>
        [JsonPropertyName("comments")]
        public string? Comments { get; set; }
    }

    /// <summary>
    /// 节点类型 (地理)
    /// </summary>
    public enum NodeClassify
    {
        /// <summary>
        /// 中国大陆
        /// </summary>
        ChinaMainland = 1,

        ChinaHTM = 2,
        /// <summary>
        /// 中国香港
        /// </summary>
        ChinaHongKong = 2,
        /// <summary>
        /// 中国台湾
        /// </summary>
        ChinaTaiwan = 2,
        /// <summary>
        /// 中国澳门
        /// </summary>
        ChinaMacau = 2,
        /// <summary>
        /// 外国主机
        /// </summary>
        Foreign = 3,
    }

    /// <summary>
    /// 节点类型支持
    /// </summary>
    public class NodeProtocolSupport
    {
        /// <summary>
        /// TCP
        /// </summary>
        [JsonPropertyName("tcp")]
        public bool TCP { get; set; }
        /// <summary>
        /// UDP
        /// </summary>
        [JsonPropertyName("udp")]
        public bool UDP { get; set; }
        /// <summary>
        /// HTTP
        /// </summary>
        [JsonPropertyName("http")]
        public bool HTTP { get; set; }
        /// <summary>
        /// HTTPS
        /// </summary>
        [JsonPropertyName("https")]
        public bool HTTPS { get; set; }
    }

    /// <summary>
    /// 节点端口限制
    /// </summary>
    public class NodePortRange
    {
        /// <summary>
        /// 类型合并
        /// </summary>
        public static implicit operator NodePortRange(string? data)
        {
            if (string.IsNullOrEmpty(data)) return new NodePortRange();

            string[] mana = data!.Substring(1, data.Length - 2).Split(',');

            var para = new NodePortRange()
            {

            };

            foreach (var vi in mana)
            {
                if (int.TryParse(vi, out var vl))
                {
                    if (para.MinValue.Equals(-1)) para.MinValue = vl;
                    else para.MaxValue = vl;
                }
            }

            return para;
        }



        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get; set; } = -1;

        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get; set; } = -1;

#if NETFRAMEWORK
        private static Random rand = new Random();
#endif

        private static (int, int)[] passPort = new (int, int)[]
        {
            (25565,25565),
            (8000,8500)
        };

        /// <summary>
        /// 取随机端口
        /// </summary>
        /// <returns></returns>
        public ushort GetRandomRemotePort()
        {
            if (MinValue is -1 or 0 || MaxValue is -1 or 0)
            {
#if NET
                int val = Random.Shared.Next(20000, 65535);
#else
                int val = rand.Next(20000, 65535);
#endif

                foreach (var item in passPort)
                {
                    if (item.Item1 >= val && item.Item2 <= val)
                    {
                        return GetRandomRemotePort();
                    }
                }

                if (val > ushort.MinValue && val < ushort.MaxValue)
                {
                    return (ushort)val;
                }
                else
                {
                    return GetRandomRemotePort();
                }
            }

#if NET
            int val2 = Random.Shared.Next(MinValue, MaxValue);
#else
            int val2 = rand.Next(MinValue, MaxValue);
#endif

            foreach (var item in passPort)
            {
                if (item.Item1 >= val2 && item.Item2 <= val2)
                {
                    return GetRandomRemotePort();
                }
            }

            if (val2 > ushort.MinValue && val2 < ushort.MaxValue)
            {
                return (ushort)val2;
            }
            else
            {
                return GetRandomRemotePort();
            }
        }
    }
}
