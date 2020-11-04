using FDD.OpenAPI.Models;
using FDD.OpenAPI.Models.addCompanySeal;
using FDD.OpenAPI.Models.cancelSealAuth;
using FDD.OpenAPI.Models.companySealDetail;
using FDD.OpenAPI.Models.companySealList;
using FDD.OpenAPI.Models.createByDraftId;
using FDD.OpenAPI.Models.createByFile;
using FDD.OpenAPI.Models.delCompanySeal;
using FDD.OpenAPI.Models.sealAuth;
using FDD.Utility;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FDD.OpenAPI
{
    /// <summary>
    /// @author zhangyongliang
    /// @version 3.0.0
    /// @date 2020/09/14
    /// </summary>
    public abstract class ClientBase
    {
        /// <summary>
        /// 通用配置项
        /// </summary>
        protected Configuration _configuration;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public ClientBase(Configuration configuration)
        {
            this._configuration = configuration;
        }

        #region 3.1 获取令牌
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public accessTokenOutput accessTokenRequest(accessTokenInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            SortedDictionary<String, object> sortDic = new SortedDictionary<String, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Grant-Type", input.GrantType);
            var headdic = SignUtil.ParseDic(sortDic, input, configuration);
            HttpHelper httphelp = new HttpHelper();
            var responseJson= httphelp.PostHttpResponse(url, headdic, "utf-8");
            return JsonConvert.DeserializeObject<accessTokenOutput>(responseJson);
        }
        #endregion

        #region 3.2 获取用户授权地址
        /// <summary>
        /// 获取用户授权地址
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getAuthorizeUrlOutPut getAuthorizeUrlRequest(getAuthorizeUrlInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("unionId", input.unionId);
            bodyDic.Add("redirectUrl", input.redirectUrl);
            bodyDic.Add("scope", input.scope);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getAuthorizeUrlOutPut>(responseJson);
        }
        #endregion

        #region 3.3 获取个人unionId地址
        /// <summary>
        /// 获取个人unionId地址
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getPersonUnionIdUrlOutPut getPersonUnionIdUrlRequest(getPersonUnionIdUrlInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("clientId", input.clientId);
            bodyDic.Add("redirectUrl", input.redirectUrl);
            bodyDic.Add("notice", input.notice);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getPersonUnionIdUrlOutPut>(responseJson);
        }
        #endregion

        #region 3.4 获取企业unionId地址
        /// <summary>
        /// 获取企业unionId地址
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getCompanyUnionIdUrlOutPut getCompanyUnionIdUrlRequest(getCompanyUnionIdUrlInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("clientId", input.clientId);
            bodyDic.Add("redirectUrl", input.redirectUrl);
            bodyDic.Add("company", input.company);
            bodyDic.Add("applicant", input.applicant);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getCompanyUnionIdUrlOutPut>(responseJson);
        }
        #endregion

        #region 3.5 获取个人实名信息
        /// <summary>
        /// 获取个人实名信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getPersonInfoRequest(getPersonInfoInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("unionId", input.unionId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return responseJson;
        }
        #endregion

        #region 3.6 获取企业实名信息
        /// <summary>
        /// 获取企业实名信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getCompanyInfoOutPut getCompanyInfoRequest(getCompanyInfoInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("unionId", input.unionId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getCompanyInfoOutPut>(responseJson);
        }
        #endregion

        #region 3.7 原始文件上传
        /// <summary>
        /// 原始文件上传
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public uploadFileOutPut uploadFileRequest(uploadFileInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("fileType", input.fileType);
            bodyDic.Add("fileContentHash", input.fileContentHash);
            //bodyDic.Add("fileContent", input.fileContent);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            httpRequestClient.SetFieldValue("fileContent", Path.GetFileName(input.fileContent), "application/octet-stream", CryptTool.FileToStream(input.fileContent));
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<uploadFileOutPut>(responseJson);
        }
        #endregion

        #region 3.8 获取模板详情
        /// <summary>
        /// 获取模板详情
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getTemplateDetailByIdRequest(getTemplateDetailByIdInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("templateId", input.templateId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return responseJson;
        }
        #endregion

        #region 3.9 模板填充
        /// <summary>
        /// 模板填充
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public createByTemplateOutPut createByTemplateRequest(createByTemplateInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("templateId", input.templateId);
            bodyDic.Add("templateFiles", input.templateFiles);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<createByTemplateOutPut>(responseJson);
        }
        #endregion

        #region 3.10 草稿文件下载
        /// <summary>
        /// 草稿文件下载
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] getByDraftIdRequest(getByDraftIdInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("draftId", input.draftId);
            bodyDic.Add("draftFileId", input.draftFileId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            byte[] responseBytes;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Download(url, headDic, out responseBytes);
            return responseBytes;
        }
        #endregion

        #region 3.11 签署文件下载
        /// <summary>
        /// 签署文件下载
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] getBySignFileIdRequest(getBySignFileIdInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskId", input.taskId);
            bodyDic.Add("signFileId", input.signFileId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            byte[] responseBytes;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Download(url, headDic, out responseBytes);
            return responseBytes;
        }
        #endregion

        #region 3.12 依据原始文件创建签署任务
        /// <summary>
        /// 依据原始文件创建签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public createByFileOutPut createByFileRequest(createByFileInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskSubject", input.taskSubject);
            bodyDic.Add("status", input.status);
            bodyDic.Add("sort", input.sort);
            bodyDic.Add("files", input.files);
            bodyDic.Add("signers", input.signers);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<createByFileOutPut>(responseJson);
        }
        #endregion

        #region 3.13 获取签署任务发起链接
        /// <summary>
        /// 获取签署任务发起链接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getSentUrlOutPut getSentUrlRequest(getSentUrlInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskId", input.taskId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getSentUrlOutPut>(responseJson);
        }
        #endregion

        #region 3.14 依据模板创建签署任务
        /// <summary>
        /// 依据模板创建签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public createByDraftIdOutPut createByDraftIdRequest(createByDraftIdInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskSubject", input.taskSubject);
            bodyDic.Add("draftId", input.draftId);
            bodyDic.Add("status", input.status);
            bodyDic.Add("sort", input.sort);
            bodyDic.Add("signers", input.signers);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<createByDraftIdOutPut>(responseJson);
        }
        #endregion

        #region 3.15 获取签署链接
        /// <summary>
        /// 获取签署链接
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getSignUrlOutPut getSignUrlRequest(getSignUrlInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskId", input.taskId);
            bodyDic.Add("unionId", input.unionId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getSignUrlOutPut>(responseJson);
        }
        #endregion

        #region 3.16 查询签署任务详情
        /// <summary>
        /// 查询签署任务详情
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public getTaskDetailByTaskIdOutPut getTaskDetailByTaskIdRequest(getTaskDetailByTaskIdInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskId", input.taskId);
            bodyDic.Add("unionId", input.unionId);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<getTaskDetailByTaskIdOutPut>(responseJson);
        }
        #endregion

        #region 3.17 撤销签署任务
        /// <summary>
        /// 撤销签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public cancelOutPut cancelRequest(cancelInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("taskId", input.taskId);
            bodyDic.Add("remark", input.remark);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<cancelOutPut>(responseJson);
        }
        #endregion

        #region 3.18 新增员工
        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public addEmployeeOutPut addEmployeeRequest(addEmployeeInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("employeeInfo", input.employeeInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<addEmployeeOutPut>(responseJson);
        }
        #endregion

        #region 3.19 删除员工
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public delEmployeeOutPut delEmployeeRequest(delEmployeeInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("employeeInfo", input.employeeInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<delEmployeeOutPut>(responseJson);
        }
        #endregion

        #region 3.20 上传企业印章
        /// <summary>
        /// 上传企业印章
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public addCompanySealOutPut addCompanySealRequest(addCompanySealInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            //bodyDic.Add("image", input.image);
            bodyDic.Add("sealInfo", input.sealInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            httpRequestClient.SetFieldValue("image", Path.GetFileName(input.image), "application/octet-stream", CryptTool.FileToStream(input.image));
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<addCompanySealOutPut>(responseJson);
        }
        #endregion

        #region 3.21 删除企业印章
        /// <summary>
        /// 3.21 删除企业印章
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public delCompanySealOutPut delCompanySealRequest(delCompanySealInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("sealInfo", input.sealInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<delCompanySealOutPut>(responseJson);
        }
        #endregion

        #region 3.22 印章授权
        /// <summary>
        /// 3.22 印章授权
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public sealAuthOutPut sealAuthRequest(sealAuthInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("sealInfo", input.sealInfo);
            bodyDic.Add("employeeInfo", input.employeeInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<sealAuthOutPut>(responseJson);
        }
        #endregion

        #region  3.23 取消授权
        /// <summary>
        ///  3.23 取消授权
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public cancelSealAuthOutPut cancelSealAuthRequest(cancelSealAuthInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("sealInfo", input.sealInfo);
            bodyDic.Add("employeeInfo", input.employeeInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<cancelSealAuthOutPut>(responseJson);
        }
        #endregion

        #region   3.24 查询企业印章列表
        /// <summary>
        ///  3.24 查询企业印章列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public string companySealListRequest(companySealListInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("sealInfo", input.sealInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return responseJson;
        }
        #endregion

        #region   3.25 查询企业印章详情
        /// <summary>
        /// 3.25 查询企业印章详情
        /// </summary>
        /// <param name="input"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public companySealDetailOutPut companySealDetailRequest(companySealDetailInput input, Configuration configuration, string url)
        {
            if (input == null)
            {
                throw new ArgumentNullException("输入的参数不能为空.");
            }
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("请求后台的连接地址不能为空.");
            }
            input.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
            //业务参数签名的字典
            var sortDic = new SortedDictionary<string, object>();
            sortDic.Add("X-FDD-Api-App-Id", configuration.AppId);
            sortDic.Add("X-FDD-Api-Sign-Type", input.SignType);
            sortDic.Add("X-FDD-Api-Timestamp", input.Timestamp);
            sortDic.Add("X-FDD-Api-Nonce", input.Nonce);
            sortDic.Add("X-FDD-Api-Token", input.Token);
            IDictionary<string, object> bodyDic = new Dictionary<string, object>();
            bodyDic.Add("sealInfo", input.sealInfo);
            sortDic.Add("bizContent", JsonConvert.SerializeObject(bodyDic));
            var headDic = SignUtil.ParseDic(sortDic, input, configuration);
            var responseJson = string.Empty;
            HttpRequestClient httpRequestClient = new HttpRequestClient();
            foreach (KeyValuePair<string, object> kvp in headDic)
            {
                httpRequestClient.SetFieldValue(kvp.Key, kvp.Value.ToString());
            }
            httpRequestClient.Upload(url, headDic, out responseJson);
            return JsonConvert.DeserializeObject<companySealDetailOutPut>(responseJson);
        }
        #endregion
    }
}
