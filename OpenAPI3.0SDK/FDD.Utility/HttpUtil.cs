using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace FDD.Utility
{
    /// <summary>
    /// @author zhangyongliang
    /// @version 3.0.0
    /// @date 2020/09/11
    /// Http上传文件类 - HttpWebRequest封装
    /// </summary>
    public class HttpUtil
    {
        /// <summary>
        /// 上传执行 方法
        /// </summary>
        /// <param name="parameter">上传文件请求参数</param>
        public static string UploadFile(HttpRequestParameter parameter)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // 1.分界线

                    string boundary = string.Format("----{0}", DateTime.Now.Ticks.ToString("x")),       // 分界线可以自定义参数
                        beginBoundary = string.Format("--{0}\r\n", boundary),
                        endBoundary = string.Format("\r\n--{0}--\r\n", boundary);

                    byte[] beginBoundaryBytes = parameter.Encoding.GetBytes(beginBoundary),
                        endBoundaryBytes = parameter.Encoding.GetBytes(endBoundary);
                    // 2.组装开始分界线数据体 到内存流中

                    memoryStream.Write(beginBoundaryBytes, 0, beginBoundaryBytes.Length);
                    // 3.组装 上传文件附加携带的参数 到内存流中

                    if (parameter.PostParameters != null && parameter.PostParameters.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> keyValuePair in parameter.PostParameters)
                        {
                            string parameterHeaderTemplate = string.Format("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n{2}", keyValuePair.Key, keyValuePair.Value, beginBoundary);
                            byte[] parameterHeaderBytes = parameter.Encoding.GetBytes(parameterHeaderTemplate);
                            memoryStream.Write(parameterHeaderBytes, 0, parameterHeaderBytes.Length);
                        }
                    }
                    // 4.组装文件头数据体 到内存流中
                    string fileHeaderTemplate = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n", parameter.FileNameKey, parameter.FileNameValue);
                    byte[] fileHeaderBytes = parameter.Encoding.GetBytes(fileHeaderTemplate);
                    memoryStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                    // 5.组装文件流 到内存流中
                    byte[] buffer = new byte[1024 * 1024 * 1];
                    int size = parameter.UploadStream.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        memoryStream.Write(buffer, 0, size);
                        size = parameter.UploadStream.Read(buffer, 0, buffer.Length);
                    }
                    // 6.组装结束分界线数据体 到内存流中
                    memoryStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                    // 7.获取二进制数据
                    byte[] postBytes = memoryStream.ToArray();
                    // 8.HttpWebRequest 组装
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(parameter.Url, UriKind.RelativeOrAbsolute));
                    webRequest.Method = "POST";
                    webRequest.Timeout = 10000;
                    foreach (var item in parameter.Headers)
                    {
                        webRequest.Headers.Add(item.Key.ToString(), item.Value.ToString());
                    }
                    //webRequest.Headers.Add("Authorization", parameter.AccessToken);
                    webRequest.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
                    webRequest.ContentLength = postBytes.Length;
                    if (Regex.IsMatch(parameter.Url, "^https://"))
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                        ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                    }
                    // 9.写入上传请求数据
                    using (Stream requestStream = webRequest.GetRequestStream())
                    {
                        requestStream.Write(postBytes, 0, postBytes.Length);
                        requestStream.Close();
                    }
                    // 10.获取响应
                    using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), parameter.Encoding))
                        {
                            string body = reader.ReadToEnd();
                            reader.Close();
                            return body;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="requestParameter">请求报文</param>
        /// <returns>响应报文</returns>
        public static HttpResponseParameter SendHttp(HttpRequestParameter requestParameter)
        {
            // 1.实例化
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestParameter.Url);
                // 2.设置请求头
                SetHeader(webRequest, requestParameter);
                // 3.设置请求Cookie
                //SetCookie(webRequest, requestParameter);
                // 4.ssl/https请求设置
                if (Regex.IsMatch(requestParameter.Url, "^https://"))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                }
                // 5.设置请求参数[Post方式下]
                SetParameter(webRequest, requestParameter);
                // 6.返回响应报文
                return SetResponse(webRequest, requestParameter);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 设置请求头
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        static void SetHeader(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            webRequest.Method = requestParameter.HttpType;
            webRequest.ContentType = requestParameter.ContextType; //"application/x-www-form-urlencoded";
            if (requestParameter.Headers != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in requestParameter.Headers)
                {
                    webRequest.Headers.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                }
            }

            //if (!string.IsNullOrWhiteSpace(requestParameter.Authorization))
            //{
            //    webRequest.Headers.Add("Authorization", requestParameter.Authorization);
            //}
            //if (!string.IsNullOrWhiteSpace(requestParameter.AccessToken))
            //{
            //    webRequest.Headers.Add("Authorization", requestParameter.AccessToken);
            //}
            webRequest.Accept = "text/html, application/xhtml+xml, */*";
            webRequest.KeepAlive = true;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko/20100101 Firefox/22.0";
            webRequest.AllowAutoRedirect = true;
            webRequest.ProtocolVersion = HttpVersion.Version10;
        }




        /// <summary>
        /// 设置请求参数（只有Post请求方式才设置）
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        static void SetParameter(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            // if (requestParameter.PostParameters == null || requestParameter.PostParameters.Count <= 0) return;

            if (requestParameter.HttpType == "POST" || requestParameter.HttpType == "PUT")
            {
                string para = string.Empty;
                StringBuilder data = new StringBuilder(string.Empty);
                if (requestParameter.DataType.Equals("form"))
                {
                    foreach (KeyValuePair<string, object> keyValuePair in requestParameter.PostParameters)
                    {
                        data.AppendFormat("{0}={1}&", keyValuePair.Key, keyValuePair.Value);
                    }
                    para = data.Remove(data.Length - 1, 1).ToString();
                    //para = data.Remove(0, 1).ToString();
                }
                if (requestParameter.DataType.Equals("json"))
                {
                    para = requestParameter.Jsondata;
                }
                byte[] bytePosts = requestParameter.Encoding.GetBytes(para);
                webRequest.ContentLength = bytePosts.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(bytePosts, 0, bytePosts.Length);
                    requestStream.Close();
                }
            }
        }

        /// <summary>
        /// 返回响应报文
        /// </summary>
        /// <param name="webRequest">HttpWebRequest对象</param>
        /// <param name="requestParameter">请求参数对象</param>
        /// <returns>响应对象</returns>
        static HttpResponseParameter SetResponse(HttpWebRequest webRequest, HttpRequestParameter requestParameter)
        {
            HttpResponseParameter responseParameter = new HttpResponseParameter();
            try
            {
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    responseParameter.Uri = webResponse.ResponseUri;
                    responseParameter.StatusCode = webResponse.StatusCode;
                    //responseParameter.Cookie = new HttpCookieType
                    //{
                    //    CookieCollection = webResponse.Cookies,
                    //    CookieString = webResponse.Headers["Set-Cookie"]
                    //};
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), requestParameter.Encoding))
                    {
                        responseParameter.Body = reader.ReadToEnd();
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                //响应流

                var mResponse = ex.Response as HttpWebResponse;
                var responseStream = mResponse.GetResponseStream();
                if (responseStream != null)
                {
                    var streamReader = new StreamReader(responseStream, Encoding.UTF8);
                    //获取返回的信息
                    string result = streamReader.ReadToEnd();
                    streamReader.Close();
                    responseStream.Close();
                    responseParameter.Body = result;
                }
            }

            return responseParameter;
        }

    }
}
