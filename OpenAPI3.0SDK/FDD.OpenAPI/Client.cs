using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FDD.OpenAPI
{
    /// <summary>
    /// @author zhangyongliang
    /// @version 3.0.0
    /// @date 2020/09/16
    /// </summary>
    public class Client:ClientBase
    {
        protected Configuration _configuration;
        public Client(Configuration configuration)
            : base(configuration)
        {
            this._configuration = configuration;
        }
        /// <summary>
        /// 3.1 获取令牌 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public accessTokenOutput accessToken(accessTokenInput input)
        {
            return base.accessTokenRequest(input, _configuration, _configuration.Gateway + Apis.AccessToken);
        }
        /// <summary>
        /// 3.2 获取用户授权地址 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getAuthorizeUrlOutPut getAuthorizeUrl(getAuthorizeUrlInput input)
        {
            return base.getAuthorizeUrlRequest(input, _configuration, _configuration.Gateway + Apis.GetAuthorizeUrl);
        }
        /// <summary>
        /// 3.3 获取个人unionId地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getPersonUnionIdUrlOutPut getPersonUnionIdUrl(getPersonUnionIdUrlInput input)
        {
            return base.getPersonUnionIdUrlRequest(input, _configuration, _configuration.Gateway + Apis.GetPersonUnionIdUrl);
        }

        /// <summary>
        /// 3.4 获取企业unionId地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getCompanyUnionIdUrlOutPut getCompanyUnionIdUrl(getCompanyUnionIdUrlInput input)
        {
            return base.getCompanyUnionIdUrlRequest(input, _configuration, _configuration.Gateway + Apis.GetCompanyUnionIdUrl);
        }
        /// <summary>
        /// 3.5 获取个人实名信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getPersonInfo(getPersonInfoInput input)
        {
            return base.getPersonInfoRequest(input, _configuration, _configuration.Gateway + Apis.GetPersonInfo);
        }

        /// <summary>
        /// 3.6 获取企业实名信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getCompanyInfoOutPut getCompanyInfo(getCompanyInfoInput input)
        {
            return base.getCompanyInfoRequest(input, _configuration, _configuration.Gateway + Apis.GetCompanyInfo);
        }

        /// <summary>
        /// 3.7 原始文件上传
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public uploadFileOutPut uploadFile(uploadFileInput input)
        {
            return base.uploadFileRequest(input, _configuration, _configuration.Gateway + Apis.UploadFile);
        }
        /// <summary>
        /// 3.8 获取模板详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getTemplateDetailById(getTemplateDetailByIdInput input)
        {
            return base.getTemplateDetailByIdRequest(input, _configuration, _configuration.Gateway + Apis.GetTemplateDetailById);
        }

        /// <summary>
        /// 3.9 模板填充
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public createByTemplateOutPut createByTemplate(createByTemplateInput input)
        {
            return base.createByTemplateRequest(input, _configuration, _configuration.Gateway + Apis.CreateByTemplate);
        }

        /// <summary>
        /// 3.10 草稿文件下载
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] getByDraftId(getByDraftIdInput input)
        {
            return base.getByDraftIdRequest(input, _configuration, _configuration.Gateway + Apis.GetByDraftId);
        }

        /// <summary>
        /// 3.11 签署文件下载
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] getBySignFileId(getBySignFileIdInput input)
        {
            return base.getBySignFileIdRequest(input, _configuration, _configuration.Gateway + Apis.GetBySignFileId);
        }
        /// <summary>
        /// 3.12 依据原始文件创建签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public createByFileOutPut createByFile(createByFileInput input)
        {
            return base.createByFileRequest(input, _configuration, _configuration.Gateway + Apis.CreateByFile);
        }
        /// <summary>
        /// 3.13 获取签署任务发起链接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getSentUrlOutPut getSentUrl(getSentUrlInput input)
        {
            return base.getSentUrlRequest(input, _configuration, _configuration.Gateway + Apis.GetSentUrl);
        }
        /// <summary>
        /// 3.14 依据模板创建签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public createByDraftIdOutPut createByDraftId(createByDraftIdInput input)
        {
            return base.createByDraftIdRequest(input, _configuration, _configuration.Gateway + Apis.CreateByDraftId);
        }
        /// <summary>
        /// 3.15 获取签署链接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getSignUrlOutPut getSignUrl(getSignUrlInput input)
        {
            return base.getSignUrlRequest(input, _configuration, _configuration.Gateway + Apis.GetSignUrl);
        }
        /// <summary>
        /// 3.16 查询签署任务详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public getTaskDetailByTaskIdOutPut getTaskDetailByTaskId(getTaskDetailByTaskIdInput input)
        {
            return base.getTaskDetailByTaskIdRequest(input, _configuration, _configuration.Gateway + Apis.GetTaskDetailByTaskId);
        }
        /// <summary>
        /// 3.17 撤销签署任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public cancelOutPut cancel(cancelInput input)
        {
            return base.cancelRequest(input, _configuration, _configuration.Gateway + Apis.Cancel);
        }
        /// <summary>
        /// 3.18 新增员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public addEmployeeOutPut addEmployee(addEmployeeInput input)
        {
            return base.addEmployeeRequest(input, _configuration, _configuration.Gateway + Apis.AddEmployee);
        }
        /// <summary>
        /// 3.19 删除员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public delEmployeeOutPut delEmployee(delEmployeeInput input)
        {
            return base.delEmployeeRequest(input, _configuration, _configuration.Gateway + Apis.DelEmployee);
        }
        /// <summary>
        /// 3.20 上传企业印章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public addCompanySealOutPut addCompanySeal(addCompanySealInput input)
        {
            return base.addCompanySealRequest(input, _configuration, _configuration.Gateway + Apis.AddCompanySeal);
        }
        /// <summary>
        /// 3.21 删除企业印章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public delCompanySealOutPut delCompanySeal(delCompanySealInput input)
        {
            return base.delCompanySealRequest(input, _configuration, _configuration.Gateway + Apis.DelCompanySeal);
        }
        /// <summary>
        /// 3.22 印章授权
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public sealAuthOutPut sealAuth(sealAuthInput input)
        {
            return base.sealAuthRequest(input, _configuration, _configuration.Gateway + Apis.SealAuth);
        }
        /// <summary>
        /// 3.23 取消授权
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public cancelSealAuthOutPut cancelSealAuth(cancelSealAuthInput input)
        {
            return base.cancelSealAuthRequest(input, _configuration, _configuration.Gateway + Apis.CancelSealAuth);
        }

        /// <summary>
        /// 3.24 查询企业印章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string companySealList(companySealListInput input)
        {
            return base.companySealListRequest(input, _configuration, _configuration.Gateway + Apis.CompanySealList);
        }
        /// <summary>
        /// 3.25 查询企业印章详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public companySealDetailOutPut companySealDetail(companySealDetailInput input)
        {
            return base.companySealDetailRequest(input, _configuration, _configuration.Gateway + Apis.CompanySealDetail);
        }
    }
}
