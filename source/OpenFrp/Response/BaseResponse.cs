using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
namespace Yue3.Model.OpenFrp.Response
{
    public class BaseResponse
    {
        [JsonPropertyName("flag")]
        public bool Flag { get; set; }

        [JsonPropertyName("msg")]
        public string? Message { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}
