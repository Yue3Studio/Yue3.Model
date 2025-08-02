using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.NatayarkAuth.Response.Data
{
    public class Authorization
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
