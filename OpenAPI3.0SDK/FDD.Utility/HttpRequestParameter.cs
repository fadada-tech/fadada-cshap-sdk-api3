using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FDD.Utility
{
    /// <summary>
    /// 上传文件 - 请求参数类
    /// </summary>
    public class HttpRequestParameter
    {

        /// <summary>
        /// 上传地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 文件名称key
        /// </summary>
        public string FileNameKey { get; set; }
        /// <summary>
        /// 文件名称value
        /// </summary>
        public string FileNameValue { get; set; }
        /// <summary>
        /// 编码格式
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 上传文件的流
        /// </summary>
        public Stream UploadStream { get; set; }
        /// <summary>
        /// 上传文件 携带的参数集合
        /// </summary>
        public IDictionary<string, object> PostParameters { get; set; }

        public IDictionary<string, object> Headers { get; set; }

        ///// <summary>
        ///// token
        ///// </summary>
        //public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public bool IsPost { get; set; }

        public string HttpType { get; set; }

        public string DataType { get; set; }

        public string Jsondata { get; set; }

        public string ContextType { get; set; }

        //public string ConsumerKey { get; set; }

        //public string ConsumerSecret { get; set; }

        //public string AccessToken { get; set; }

        //public string Authorization { get; set; }
    }
}
