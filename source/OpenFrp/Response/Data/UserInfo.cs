using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    public class UserInfoData : UserInfo { }
    public class UserInfo
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = "";

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; } = "";

        /// <summary>
        /// 用户所在组名称
        /// </summary>
        [JsonPropertyName("friendlyGroup")]
        public string GroupCName { get; set; } = "普通用户";
        /// <summary>
        /// 用户所在组
        /// </summary>
        [JsonPropertyName("group")]
        public string Group { get; set; } = "normal";

        /// <summary>
        /// 用户 ID
        /// </summary>
        [JsonPropertyName("id")]
        public int UserID { get; set; }

        /// <summary>
        /// 最大隧道数量
        /// </summary>
        [JsonPropertyName("proxies")]
        public int MaxProxies { get; set; }
        /// <summary>
        /// 已使用的隧道数
        /// </summary>
        [JsonPropertyName("used")]
        public int UsedProxies { get; set; }

        /// <summary>
        /// 可用流量
        /// </summary>
        [JsonPropertyName("traffic")]
        public long Traffic { get; set; }

        /// <summary>
        /// 用户 Token
        /// </summary>
        [DebuggerHidden()]
        [JsonPropertyName("token")]
        public string? UserToken { get; set; }

        /// <summary>
        /// 是否已实名
        /// </summary>
        [JsonPropertyName("realname")]
        public bool IsRealname { get; set; }
        /// <summary>
        /// 入口带宽速率
        /// </summary>
        [JsonPropertyName("inLimit")]
        public int InputLimit { get; set; }
        /// <summary>
        /// 出口带宽速率
        /// </summary>
        [JsonPropertyName("outLimit")]
        public int OutputLimit { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [JsonPropertyName("regTime")]
        public string? RegisterTime { get; set; }



        public override bool Equals(object? obj)
        {
            if (obj is UserInfo { Email: string em,RegisterTime: string rt,UserID: int ti } )
            {
                return em.Equals(this.Email) && rt.Equals(this.RegisterTime) && ti.Equals(this.UserID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
