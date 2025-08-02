using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.NatayarkAuth.Request
{
    /// <summary>
    /// 登录请求
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("user")]
        public string? Username { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        private string GetDebuggerDisplay()
        {
            return $"用户名: {Username},密码: {Password}";
        }
    }
}
