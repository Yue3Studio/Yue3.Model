using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Request
{
    /// <summary>
    /// 通过Access 请求登录
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class AccessLoginRequest
    {
        public AccessLoginRequest()
        {

        }

        public AccessLoginRequest(string public_key)
        {
            this.PublicKey = public_key;
        }

        /// <summary>
        /// 公钥
        /// </summary>
        [JsonPropertyName("public_key")]
        public string? PublicKey { get; set; }

        private static object GetDebuggerDisplay()
        {
            throw new NotImplementedException();
        }
    }
}
