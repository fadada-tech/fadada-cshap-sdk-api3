using System;
using FDD.OpenAPI;
using Newtonsoft.Json;
using FDD.OpenAPI.SDKModels.Accounts;
using FDD.OpenAPI.SDKModels.Documents;
using FDD.OpenAPI.Utility;
using FDD.OpenAPI.SDKModels.Signtasks;
using FDD.OpenAPI.SDKModels.Template;
using FDD.OpenAPI.SDKModels.ReviseTask;
using FDD.OpenAPI.SDKModels.Seal;
using FDD.OpenAPI.SDKModels.Organization;
using FDD.OpenAPI.SDKModels.Oauth2;
using FDD.OpenAPI.SDKModels.ThirdUser;
using System.Collections.Generic;
using static FDD.OpenAPI.SDKModels.Template.TemplatInitRequest;

namespace FDD.Test
{
    class Program
    {
        /// <summary>
        /// @author zhangyongliang
        /// @version 3.1.0
        /// @date 2020/01/25
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var ServerUrl = "https://sandboxapi.fadada.com/api/v3";
            var AppId = "FA67694018";
            var AppKey = "UNPRNJ8M35RUBJCTVOTJSL2AXQRLGMZS";
            //var client = new OpenClient(ServerUrl, AppId, AppKey);
            var client = new EcologicalClient(ServerUrl, AppId, AppKey);

            //#region 3.1.1 获取接入方实名绑定信息
            //var result1 = client.Execute(new GetAccessObjectInfoRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result1));
            //#endregion

            //#region 3.1.2 获取个人实名绑定地址
            //var result2 = client.Execute(new GetPersonUnionIdUrlRequest()
            //{
            //    clientId = "1111111",
            //    redirectUrl = "http://www.shouhu.com"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result2));
            //#endregion

            //#region 3.1.3 获取企业实名绑定地址
            //var result3 = client.Execute(new GetCompanyUnionIdUrlRequest()
            //{
            //    clientId = "6666666666666",
            //    company = new GetCompanyUnionIdUrlRequest.Company()
            //    {
            //        companyName = "abccompany"
            //    },
            //    redirectUrl = "http://www.shouhu.com",
            //    applicant = new GetCompanyUnionIdUrlRequest.Applicant()
            //    {
            //        applicantType = "1",
            //        unionId = "28374"
            //    }
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result3));
            //#endregion

            //#region 3.1.4 获取用户实名信息授权地址
            //var result4 = client.Execute(new GetAuthorizeUrlRequest()
            //{
            //    unionId = "33333",
            //    scope="1",
            //    redirectUrl = "http://www.shouhu.com"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result4));
            //#endregion

            //#region 3.1.5 个人实名信息查询
            //var result5 = client.Execute(new GetPersonInfoRequest()
            //{
            //    unionId = "66666"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result5));
            //#endregion

            //#region 3.1.6 企业实名信息查询
            //var result6 = client.Execute(new GetCompanyInfoRequest()
            //{
            //    unionId = "666"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result6));
            //#endregion

            //#region 3.1.7 原始文件上传
            //var file = new FileItem(@"D:\333.pdf");
            //var result7 = client.Execute(new UploadFileRequest()
            //{
            //    fileType = 1,
            //    fileContent = file,
            //    fileContentHash = CryptTool.HashDataString(file.Stream, "sha256").ToLower()
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result7));
            //#endregion

            //#region 3.1.8 草稿文件下载
            //var result8 = client.Execute(new GetByDraftIdRequest()
            //{
            //    draftId = "87648763987"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result8));
            //#endregion

            //#region 3.1.9 基于原始文件创建签署任务
            //var result9 = client.Execute(new CreateTaskByFileRequest()
            //{

            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result9));
            //#endregion

            //#region 3.1.10 获取签署任务发起地址
            //var result10 = client.Execute(new GetSentUrlRequest()
            //{

            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result10));
            //#endregion

            //#region 3.1.11 引用模板创建签署任务
            //var result11 = client.Execute(new CreateTaskByDraftIdRequest()
            //{

            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result11));
            //#endregion

            //#region 3.1.12 获取签署链接
            //var result12 = client.Execute(new GetSignUrlRequest()
            //{

            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result12));
            //#endregion

            //#region 3.1.13 查询签署任务详情
            //var result13 = client.Execute(new GetTaskDetailByTaskIdRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result13));
            //#endregion

            //#region 3.1.14 获取签署文件预览地址
            //var result14 = client.Execute(new GetSignPreviewUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result14));
            //#endregion

            //#region 3.1.15 签署文件下载
            //var result15 = client.Execute(new GetBySignFileIdRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result15));
            //#endregion

            //#region 3.1.16 签署任务撤销
            //var result16 = client.Execute(new OpenAPI.SDKModels.Signtasks.CancelRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result16));
            //#endregion

            //#region 3.1.17 签署任务催签
            //var result17 = client.Execute(new UrgeSignRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result17));
            //#endregion

            //#region 3.1.18 解锁签署节点
            //var result18 = client.Execute(new UnlockRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result18));
            //#endregion

            //List<Roles> lstroles = new List<Roles>();
            //var roles = new Roles()
            //{
            //    roleName = "222",
            //    roleType = 1,//角色类型，1个人、2企业
            //    rolePermission = 2,//角色权限，1填写、2签署、3填写+签署
            //};
            //lstroles.Add(roles);
            //var templateInfo = new TemplatInitRequest.TemplateInfo()
            //{
            //    templateName = "asjdfk",
            //    templateRemark = "sadfa",
            //    roles = lstroles
            //};
            //#region 3.1.19 创建模板
            //var result19 = client.Execute(new TemplatInitRequest()
            //{
            //    templateInfo= templateInfo
            //}, "0d99e32b358e466c8686bb6223092666");
            //Console.WriteLine(JsonConvert.SerializeObject(result19));
            //#endregion

            //#region 3.1.20 模板文件上传
            //var result20 = client.Execute(new UploadCompanyTemplateFileRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result20));
            //#endregion

            //#region 3.1.21 模板文件删除
            //var result21 = client.Execute(new DelCompanyTemplateFileRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result21));
            //#endregion

            //#region 3.1.22 获取模板维护地址
            //var result22 = client.Execute(new GetTemplateMainUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result22));
            //#endregion

            //#region 3.1.23 模板列表查询
            //var result23 = client.Execute(new QueryCompanyTemplateListRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result23));
            //#endregion

            #region 3.1.24 模板详情信息查询
            var result24 = client.Execute(new GetTemplateDetailRequest()
            {
                templateId = "1619069961196143640"
            });
            Console.WriteLine(JsonConvert.SerializeObject(result24));
            #endregion

            //#region 3.1.25 模板文件下载
            //var result25 = client.Execute(new DownloadCompanyTemplateFileRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result25));
            //#endregion

            //#region 3.1.26 获取模板文件预览地址
            //var result26 = client.Execute(new GetCompanyTemplatePreviewUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result26));
            //#endregion

            //#region 3.1.27 创建模板定稿任务
            //var result27 = client.Execute(new CreateReviseTaskRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result27));
            //#endregion

            //#region 3.1.28 获取在线定稿地址
            //var result28 = client.Execute(new GetFillFileUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result28));
            //#endregion

            //#region 3.1.29 定稿任务填充
            //var result29 = client.Execute(new SaveFillValuesRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result29));
            //#endregion

            //#region 3.1.30 定稿任务填充
            //var result30 = client.Execute(new CancelReviseTaskRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result30));
            //#endregion

            //#region 3.1.31 获取定稿任务详情
            //var result31 = client.Execute(new ReviseTaskDetailRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result31));
            //#endregion

            //#region 3.1.32 新增企业印章
            //var result32 = client.Execute(new AddCompanySealRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result32));
            //#endregion

            //#region 3.1.33 删除企业印章
            //var result33 = client.Execute(new DelCompanySealRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result33));
            //#endregion

            //#region 3.1.34 企业印章列表查询
            //var result34 = client.Execute(new CompanySealListRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result34));
            //#endregion

            //#region 3.1.35 企业印章详情查询
            //var result35 = client.Execute(new CompanySealDetailRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result35));
            //#endregion

            //#region 3.1.36 企业印章授权
            //var result36 = client.Execute(new SealAuthRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result36));
            //#endregion

            //#region 3.1.37 印章取消授权
            //var result37 = client.Execute(new CancelSealAuthRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result37));
            //#endregion

            //#region 3.1.38 组织架构-添加分子公司
            //var result38 = client.Execute(new GetAddSubCompanyUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result38));
            //#endregion

            //#region 3.1.39 组织架构-移除分子公司
            //var result39 = client.Execute(new RemoveSubCompanyRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result39));
            //#endregion

            //#region 3.1.40 组织架构-公司列表查询
            //var result40 = client.Execute(new GetChildCompanyListRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result40));
            //#endregion

            //#region 3.1.41 组织架构-邀请员工
            //var result41 = client.Execute(new GetAddEmployeeUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result41));
            //#endregion

            //#region 3.1.42 组织架构-移除员工
            //var result42 = client.Execute(new DelEmployeeRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result42));
            //#endregion

            //#region 3.1.43 组织架构-员工列表查询
            //var result43 = client.Execute(new GetEmployeeRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result43));
            //#endregion

            //#region 3.1.44 组织架构-变更企业管理员
            //var result44 = client.Execute(new GetChangeCompanyMajorUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result44));
            //#endregion

            //#region 3.1.45 授权管理-获取静默签授权地址
            //var result45 = client.Execute(new GetAutoSignAuthUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result45));
            //#endregion

            //#region 3.1.46 授权管理-静默签取消授权
            //var result46 = client.Execute(new CancelAuthSignAuthRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result46));
            //#endregion

            //#region 3.1.47 存证管理-技术报告下载
            //var result47 = client.Execute(new ProfessionalContractReportDownloadRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result47));
            //#endregion

            //#region 3.1.48 存证管理-公证处保全报告下载
            //var result48 = client.Execute(new DownloadEvidenceReportRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result48));
            //#endregion

            //#region 3.1.49 其他工具-签署文件验签
            //var result49 = client.Execute(new VerifySignatureRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result49));
            //#endregion

            //#region 3.1.50 其他工具-根据关键字查询坐标
            //var result50 = client.Execute(new LookUpCoordinatesRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result50));
            //#endregion

            //#region 3.1.51 其他工具-根据uuid下载文件base64
            //var result51 = client.Execute(new GetFileBase64Request()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result51));
            //#endregion

            //#region 3.1.52 其他工具-根据链接上传原始文件
            //var result52 = client.Execute(new UploadFileByUrlRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result52));
            //#endregion

            //#region 3.1.53 其他工具-根据clientId获取unionId
            //var result53 = client.Execute(new GetUnionIdsRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result53));
            //#endregion

            //#region 3.1.54 授权管理-获取法大大电子签服务开通地址
            //var result54 = client.Execute(new GetOpenServerUrlRequest()
            //{
            //    unionId="123456789",
            //    redirectUrl="www.baidu.com"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result54));
            //#endregion

            //#region 3.1.55 授权管理-关闭法大大电子签服务
            //var result55 = client.Execute(new OpenAPI.SDKModels.ThirdUser.CancelRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result55));
            //#endregion

            //#region 3.1.56 授权管理-关闭法大大电子签服务
            //var result56 = client.Execute(new GetUserTokenRequest()
            //{
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result56));
            //#endregion

            Console.ReadLine();

        }
    }
}
