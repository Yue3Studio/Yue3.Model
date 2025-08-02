using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yue3.Model.OpenFrp.Response.Data
{
    /// <summary>
    /// 软件数据
    /// </summary>
    public class SoftWareVersionData
    {
        /// <summary>
        /// 最新版本 构建号
        /// </summary>
        [JsonPropertyName("latest_full")]
        public string? Latest { get; set; }

        /// <summary>
        /// 更新内容
        /// </summary>
        [JsonPropertyName("latest_msg")]
        public string? FrpcUpdateLog { get; set; }

        /// <summary>
        /// 更新日志 2
        /// </summary>
        [JsonPropertyName("common_details")]
        public string? CommonUpdateLog { get; set; }

        /// <summary>
        /// 启动器更新
        /// </summary>
        [JsonPropertyName("launcher_inf")]
        public LauncherProperty Launcher { get; set; } = new LauncherProperty();

        /// <summary>
        /// 下载源
        /// </summary>
        [JsonPropertyName("source")]
        public DownloadSource[]? DownloadSources { get; set; }

        /// <inheritdoc/>
        public class LauncherProperty
        {
            /// <summary>
            /// 最新版本
            /// </summary>
            [JsonPropertyName("latest")]
            public string? Latest { get; set; }

            ///// <summary>
            /////  下载链接
            ///// </summary>
            //[JsonPropertyName("download")]
            //public string? Download { get; set; }


            /// <summary>
            /// 更新内容
            /// </summary>
            [JsonPropertyName("msg")]
            public string? Message { get; set; }

            /// <summary>
            /// 标题
            /// </summary>
            [JsonPropertyName("title")]
            public string? Title { get; set; }

            ///// <summary>
            ///// 下载参数
            ///// </summary>
            //[JsonPropertyName("argument")]
            //public string? Argument { get; set; }
        }

        /// <inheritdoc/>
        public class DownloadSource
        {
            /// <summary>
            /// 名称
            /// </summary>
            [JsonPropertyName("label")]
            public string? Label { get; set; }

            /// <summary>
            /// 基本路径
            /// </summary>
            [JsonPropertyName("value")]
            public string? BaseUrl { get; set; }
        }
    }
}
