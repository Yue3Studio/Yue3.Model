using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    /// <summary>
    /// 有 Total 的返回内容
    /// </summary>
    public class CollectionData<T>
    {
        /// <summary>
        /// 数据量
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// 列表内容
        /// </summary>
        [JsonPropertyName("list")]
        public T[]? List { get; set; }
    }
}
