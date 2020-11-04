using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Reflection;
using System.Net.Http;

namespace FDD.Utility
{
    /// <summary>
    /// 上传文件和字段一起打包请求公共调用
    /// </summary>
    public class HttpHelper
    {
        #region //字段
        private ArrayList bytesArray;
        private Encoding encoding = Encoding.UTF8;
        private string boundary = String.Empty;
        private bool passed;
        #endregion

        #region //构造方法
        public HttpHelper()
        {
            bytesArray = new ArrayList();
            string flag = DateTime.Now.Ticks.ToString("x");
            boundary = "---------------------------" + flag;
        }
        #endregion

        #region //方法
        /// <summary>
        /// 合并请求数据
        /// </summary>
        /// <returns></returns>
        private byte[] MergeContent()
        {
            int length = 0;
            int readLength = 0;
            string endBoundary = "--" + boundary + "--\r\n";
            byte[] endBoundaryBytes = encoding.GetBytes(endBoundary);

            bytesArray.Add(endBoundaryBytes);

            foreach (byte[] b in bytesArray)
            {
                length += b.Length;
            }

            byte[] bytes = new byte[length];

            foreach (byte[] b in bytesArray)
            {
                b.CopyTo(bytes, readLength);
                readLength += b.Length;
            }

            return bytes;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="requestUrl">请求url</param>
        /// <param name="responseText">响应</param>
        /// <returns></returns>
        public bool HttpPost(String requestUrl, out String responseText)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);

            byte[] responseBytes;
            byte[] bytes = MergeContent();

            try
            {
                responseBytes = webClient.UploadData(requestUrl, bytes);
                responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
                return true;
            }
            catch (WebException ex)
            {
                Stream responseStream = ex.Response.GetResponseStream();
                responseBytes = new byte[ex.Response.ContentLength];
                responseStream.Read(responseBytes, 0, responseBytes.Length);
            }
            responseText = System.Text.Encoding.UTF8.GetString(responseBytes);
            return false;
        }

        /// <summary>
        /// 设置表单数据字段
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>
        public void SetFieldValue(String fieldName, String fieldValue)
        {
            string httpRow = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
            string httpRowData = String.Format(httpRow, fieldName, fieldValue);

            bytesArray.Add(encoding.GetBytes(httpRowData));
        }

        /// <summary>
        /// 设置表单文件数据
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="filename">字段值</param>
        /// <param name="contentType">内容内型</param>
        /// <param name="fileBytes">文件字节流</param>
        /// <returns></returns>
        public void SetFieldValue(String fieldName, String filename, String contentType, Byte[] fileBytes)
        {
            string end = "\r\n";
            string httpRow = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string httpRowData = String.Format(httpRow, fieldName, filename, contentType);

            byte[] headerBytes = encoding.GetBytes(httpRowData);
            byte[] endBytes = encoding.GetBytes(end);
            byte[] fileDataBytes = new byte[headerBytes.Length + fileBytes.Length + endBytes.Length];

            headerBytes.CopyTo(fileDataBytes, 0);
            fileBytes.CopyTo(fileDataBytes, headerBytes.Length);
            endBytes.CopyTo(fileDataBytes, headerBytes.Length + fileBytes.Length);

            bytesArray.Add(fileDataBytes);
        }
        #endregion


        /// <summary>
        /// 普通的Post请求，只有参数没有上传文件流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Parameters"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public string PostByWebRequest(string url, IDictionary<string, object> Parameters, string encode)
        {
            try
            {
                HttpWebRequest Request = WebRequest.Create(url) as HttpWebRequest;
                Request.Method = "POST";
                Request.ContentType = "application/json";
                Request.KeepAlive = true;
                string PostData = JsonConvert.SerializeObject(Parameters);
                byte[] PostByte = Encoding.UTF8.GetBytes(PostData);
                Request.ContentLength = PostByte.Length;
                Request.GetRequestStream().Write(PostByte, 0, PostByte.Length);
                HttpWebResponse httpResponse = (HttpWebResponse)Request.GetResponse();
                string str = "";
                if (Request.HaveResponse)
                {
                    StreamReader sr;
                    if (encode != null && encode != "")
                    {
                        sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(encode));
                    }
                    else
                    {
                        sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.Default);
                    }
                    str = sr.ReadToEnd();
                    sr.Close();
                    httpResponse.Close();
                }
                return str;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                string s = ex.Message;
                return "";
            }
        }

        public string PostHttpResponse1(string url, IDictionary<string, object> headDic, IDictionary<string, object> bodyDic, string encode)
        {
            //创建连接
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            string param = "";
            var postContent = new MultipartFormDataContent();
            postContent.Headers.Add("ContentType", $"multipart/form-data");
           
            for (int i=0;i< headDic.Count;i++)
            {
                if(headDic.ToList()[i].Key == "bizContent")
                {
                    param = JsonConvert.SerializeObject(headDic.ToList()[i].Value.ToString());
                    postContent.Add(new StringContent(headDic.ToList()[i].Value.ToString()), "bizContent");
                    headDic.Remove(headDic.ToList()[i].Key);
                }
                SetHeaderValue(httpRequest.Headers, headDic.ToList()[i].Key, headDic.ToList()[i].Value.ToString());
            }
            //发送请求的方式
            httpRequest.Method = "POST";

           
           

            byte[] bs = Encoding.ASCII.GetBytes(param);
            //httpRequest.ContentType = "multipart/form-data";
            //httpRequest.ContentType = "application/json"; 
            //httpRequest.ContentLength = bs.Length;
            //using (Stream reqStream = httpRequest.GetRequestStream())
            //{
            //    reqStream.Write(bs, 0, bs.Length);
            //    reqStream.Close();
            //}
            //httpRequest.CookieContainer = new CookieContainer();

            //创建一个响应对象
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string str = "";
            if (httpRequest.HaveResponse)
            {
                StreamReader sr;
                if (encode != null && encode != "")
                {
                    sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(encode));
                }
                else
                {
                    sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.Default);
                }
                str = sr.ReadToEnd();
                sr.Close();
                httpResponse.Close();
            }
            return str;
        }
        public string PostHttpResponse(string url, IDictionary<string, object> ParametersHeads, string encode)
        {
            //Encoding gb2312 = Encoding.GetEncoding("GB2312");
            //Encoding utf8 = Encoding.GetEncoding("utf-8");
            //创建连接
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            foreach (var item in ParametersHeads)
            {
                SetHeaderValue(httpRequest.Headers, item.Key, item.Value.ToString());
            }
            //发送请求的方式
            httpRequest.Method = "POST";
            //发送的协议
            //httpRequest.Accept = "HTTP";


            //string param = "factory=factory888&position=00006789";
            //byte[] bs = Encoding.ASCII.GetBytes(param);
            //httpRequest.ContentType = "application/x-www-form-urlencoded";
            //httpRequest.ContentLength = bs.Length;
            //using (Stream reqStream = httpRequest.GetRequestStream())
            //{
            //    reqStream.Write(bs,0 , bs.Length);
            //    reqStream.Close();
            //}
            //httpRequest.CookieContainer = new CookieContainer();

            //创建一个响应对象
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string str = "";
            if (httpRequest.HaveResponse)
            {
                StreamReader sr;
                if (encode != null && encode != "")
                {
                    sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.GetEncoding(encode));
                }
                else
                {
                    sr = new StreamReader(httpResponse.GetResponseStream(), Encoding.Default);
                }
                str = sr.ReadToEnd();
                sr.Close();
                httpResponse.Close();
            }
            return str;
        }
        private void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }
        public static String doPostDownload(String path, String url, List<KeyValuePair<string, string>> Parameters)
        {
            //if (!imgUrl.Contains("http"))
            //{
            //    imgUrl = "https://" + imgUrl;
            //}
            //using (WebClient client = new WebClient())
            //{
            //    byte[] bytes = client.DownloadData(imgUrl);
            //    return Convert.ToBase64String(bytes);
            //}

            byte[] responseBytes;
            try
            {
                Uri downUri = new Uri(url);
                //建立一个ＷＥＢ请求，返回HttpWebRequest对象
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(downUri);
                if (hwr == null)
                {
                    throw new Exception("HttpWebRequest is null.");
                }

                //流对象使用完后自动关闭
                using (Stream stream = hwr.GetResponse().GetResponseStream())
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    //文件流，流信息读到文件流中，读完关闭
                    using (FileStream fs = File.Create(path))
                    {
                        //建立字节组，并设置它的大小是多少字节
                        byte[] bytes = new byte[102400];
                        int n = 1;
                        while (n > 0)
                        {
                            //一次从流中读多少字节，并把值赋给Ｎ，当读完后，Ｎ为０,并退出循环
                            n = stream.Read(bytes, 0, 10240);
                            fs.Write(bytes, 0, n); //将指定字节的流信息写入文件流中
                        }
                    }
                }
            }
            catch (WebException e)
            {
                return e.Message;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return null;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="strKey"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Encrypt3DES(string strString, string Key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = Encoding.UTF8.GetBytes(Key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            byte[] Buffer = Encoding.UTF8.GetBytes(strString);

            return ToHexString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string Decrypt3DES(string strString, string Key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

            DES.Key = Encoding.UTF8.GetBytes(Key);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            byte[] Buffer = Convert.FromBase64String(strString);
            return ToHexString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }


        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {

                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
    }
}
