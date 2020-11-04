using FDD.OpenAPI.Models;
using FDD.Utility;
using Mono.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI
{
    /// <summary>
    /// @author zhangyongliang
    /// @version 3.0.0
    /// @date 2020/09/10
    /// 签名计算
    /// </summary>
    public class SignUtil
    {
        #region 将输入对象转换为字典以便排序请求
        /// <summary>
        /// 将输入对象转换为字典以便排序请求
        /// </summary>
        /// <returns></returns>
        public static SortedDictionary<String, object> ParseDic<TInput>(SortedDictionary<String, object> sortDic, TInput input, Configuration configuration) where TInput : IbaseInput
        {
            //签名
            var sign = SignUtil.GetSign(sortDic, input, configuration);
            sortDic.Add("X-FDD-Api-Sign", sign);
            return sortDic;
        }
        #endregion

        #region 生成签名
        /// <summary>
        ///  生成签名
        /// </summary>
        /// <param name="input"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static String GetSign<TInput>(SortedDictionary<String, object> sortDic, TInput input, Configuration configuration) where TInput : IbaseInput
        {
            string sign = null;
            var sArr = sortDic.OrderBy(x => x.Key, new OrdinalComparer()).ToDictionary(x => x.Key, y => y.Value);
            StringBuilder builder = new StringBuilder();
            foreach (var item in sArr)
            {
                object value = item.Value;
                if (null != value && !"".Equals(value))
                {
                    builder.Append(item.Key).Append("=").Append(value).Append("&");
                }
            }
            string content = builder.ToString().TrimEnd('&');
            switch (input.SignType)
            {
                case "HMAC-SHA256":
                    string signText = CryptTool.sha256(content).ToLower();
                    byte[] secretSign = CryptTool.HMACSHA256Byte(input.Timestamp, configuration.AppKey);
                    sign = CryptTool.HMACSHA256Str(signText.ToLower(), secretSign);
                    break;
                default:
                    break;
            }
            return sign;
        }
        #endregion
    }
}
