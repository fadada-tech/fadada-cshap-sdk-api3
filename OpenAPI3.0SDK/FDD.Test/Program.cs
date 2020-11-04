using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDD.OpenAPI;
using FDD.OpenAPI.Models;
using FDD.OpenAPI.Models.createByFile;
using FDD.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FDD.OpenAPI.Models.delCompanySeal;
using FDD.OpenAPI.Models.sealAuth;
using FDD.OpenAPI.Models.addCompanySeal;
using FDD.OpenAPI.Models.cancelSealAuth;
using FDD.OpenAPI.Models.companySealList;
using FDD.OpenAPI.Models.companySealDetail;
using FDD.OpenAPI.Models.createByFile;
using FDD.OpenAPI.Models;


namespace FDD.Test
{
    class Program
    {
        /// <summary>
        /// @author zhangyongliang
        /// @version 3.0.0
        /// @date 2020/09/15
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var Configuration = new Configuration()
            {
                Gateway = "https://v4demo-gw.fadada.com/api/v3",
                AppId = "FA12570596",
                AppKey = "HEECPISOQXV100EMGWV4UOB6JQOH77PK"
            };

            Client client = new Client(Configuration);

            #region 3.1 获取令牌 
            //var result1 = client.accessToken(new accessTokenInput()
            //{
            //    GrantType = "client_credential",
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N")
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result1));
            #endregion

            #region 3.2 获取用户授权地址  
            //var result2 = client.getAuthorizeUrl(new getAuthorizeUrlInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    unionId = "d26cf6ad283e4094a11967881f02f7d6",
            //    redirectUrl = "https://www.baidu.com/",
            //    scope = "1"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result2));
            #endregion

            #region 3.3 获取个人unionId地址
            //var notice = new notice()
            //{
            //    notifyWay = "1",
            //    notifyAddress = "18988888888"
            //};

            //var result3 = client.getPersonUnionIdUrl(new getPersonUnionIdUrlInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    clientId = System.Guid.NewGuid().ToString("N"),
            //    notice = notice,
            //    redirectUrl = "https://www.baidu.com/"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result3));
            #endregion

            #region 3.4 获取企业unionId地址
            //var company = new company()
            //{
            //    companyName = "公司名称001"
            //};
            //var applicant = new applicant()
            //{
            //    unionId = "d26cf6ad283e4094a11967881f02f7d6"
            //};
            //var result4 = client.getCompanyUnionIdUrl(new getCompanyUnionIdUrlInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    clientId = System.Guid.NewGuid().ToString("N"),
            //    company = company,
            //    applicant = applicant,
            //    redirectUrl = "https://www.baidu.com/"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result4));
            #endregion

            #region 3.5 获取个人实名信息
            //var result5 = client.getPersonInfo(new getPersonInfoInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    unionId = "d26cf6ad283e4094a11967881f02f7d6"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result5));
            #endregion

            #region 3.6 获取企业实名信息
            //var result6 = client.getCompanyInfo(new getCompanyInfoInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    unionId = "0dbc41f8081c427d82438371812e1f2f"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result6));
            #endregion

            #region 3.7 原始文件上传
            //string fileContent = @"D:\workspacenew\SDK\授权模板.pdf";
            //var result7 = client.uploadFile(new uploadFileInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    fileContent = fileContent,
            //    fileType = "1",
            //    fileContentHash = CryptTool.HashFile(fileContent, "sha256").ToLower()
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result7));
            #endregion

            #region 3.8 获取模板详情
            //var result8 = client.getTemplateDetailById(new getTemplateDetailByIdInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    templateId = "1600065269275198965"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result8));
            #endregion

            #region 3.9 模板填充
            //List<templateFiles> list = new List<templateFiles>();
            //var formFieldsDic = new Dictionary<string, string>();
            //formFieldsDic.Add("001", "控件1");
            //var templateFiles = new templateFiles()
            //{
            //    templateFileId = "1600065270728129444",
            //    formFields = formFieldsDic,
            //    documentFileName = "草稿文件的名称001"
            //};
            //list.Add(templateFiles);
            //var result9 = client.createByTemplate(new createByTemplateInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    templateId = "1600065269275198965",
            //    templateFiles = list
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result9));
            #endregion

            #region 3.10 草稿文件下载

            //var result10 = client.getByDraftId(new getByDraftIdInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "4a41af44706649fb8aeaabf8c9380031",
            //    draftId = "1600246008483114902",
            //    draftFileId = "1600246008483148340"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result10));
            #endregion

            #region 3.11 签署文件下载

            //var result11 = client.getBySignFileId(new getBySignFileIdInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "7ee56fdc459a42c297b61782a5ce6a80",
            //    taskId = "",
            //    signFileId = ""
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result11));
            #endregion

            #region 3.12 依据原始文件创建签署任务
            //List<files> lstfile = new List<files>();
            //var file = new files()
            //{
            //    fileId = "1600249205764144199"
            //};
            //lstfile.Add(file);
            //List<OpenAPI.Models.createByFile.signers> lstsigners = new List<OpenAPI.Models.createByFile.signers>();
            //List<fileSigns> lstfileSigns = new List<fileSigns>();
            //var fileSigns = new fileSigns();
            //fileSigns.fileId = "1600249205764144199";//文件编号，原始文件上传接口返回
            //lstfileSigns.Add(fileSigns);
            //var signers = new OpenAPI.Models.createByFile.signers()
            //{
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"
            //};
            //lstsigners.Add(signers);
            //var result12 = client.createByFile(new createByFileInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskSubject = System.Guid.NewGuid().ToString("N"),
            //    status = "create",
            //    sort = 2,
            //    files = lstfile,
            //    signers = lstsigners
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result12));
            #endregion

            #region 3.13 获取签署任务发起链接
            //var result13 = client.getSentUrl(new getSentUrlInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskId = "d0eb2bef59fd4e18a082a4cace1c9613"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result13));
            #endregion

            #region 3.14 依据模板创建签署任务
            //List<OpenAPI.Models.signers> lstsigners = new List<OpenAPI.Models.signers>();
            //var signers = new OpenAPI.Models.signers()
            //{
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576",
            //    templateRoleName = "租户"
            //};
            //lstsigners.Add(signers);
            //var result14 = client.createByDraftId(new createByDraftIdInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskSubject = System.Guid.NewGuid().ToString("N"),
            //    draftId = "1600310044471134034",
            //    status = "sent",
            //    sort = 2,
            //    signers = lstsigners
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result14));
            #endregion

            #region 3.15 获取签署链接
            //var result15 = client.getSignUrl(new getSignUrlInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskId = "938f95493afc482886010e70646a2229",
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result15));
            #endregion

            #region 3.16 查询签署任务详情
            //var result16 = client.getTaskDetailByTaskId(new getTaskDetailByTaskIdInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskId = "938f95493afc482886010e70646a2229",
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result16));
            #endregion

            #region 3.17 撤销签署任务
            //var result17 = client.cancel(new cancelInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    taskId = "",
            //    remark = ""
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result17));
            #endregion

            #region 3.18 新增员工
            //var employeeInfo = new OpenAPI.Models.employeeInfo()
            //{
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"//员工个人的unionId
            //};
            //var result18 = client.addEmployee(new addEmployeeInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    employeeInfo = employeeInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result18));
            #endregion

            #region 3.19 删除员工
            //var employeeInfo = new OpenAPI.Models.employeeInfo()
            //{
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"//员工个人的unionId
            //};
            //var result19 = client.delEmployee(new delEmployeeInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "bb8c94f4904240d987bdf5ad16a1ff15",
            //    employeeInfo = employeeInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result19));
            #endregion

            #region 3.20 上传企业印章
            //string image = @"D:\workspacenew\SDK\20191108171306.png";
            //var sealInfo = new OpenAPI.Models.addCompanySeal.sealInfo()
            //{
            //    imageHash = CryptTool.HashFile(image, "sha256").ToLower(),//计算印章图片hash值(sha256), 输出hexString
            //    sealName = "签章名称001"//签章名称（长度不能大于16）
            //};
            //var result20 = client.addCompanySeal(new addCompanySealInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    image = image,
            //    sealInfo = sealInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result20));
            #endregion

            #region 3.21 删除企业印章
            //var sealInfo = new OpenAPI.Models.delCompanySeal.sealInfo()
            //{
            //    sealId = "1600323617305188527"//签章名称（长度不能大于16）
            //};
            //var result21 = client.delCompanySeal(new delCompanySealInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    sealInfo = sealInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result21));
            #endregion

            #region 3.22 印章授权
            //var sealInfo = new OpenAPI.Models.sealAuth.sealInfo()
            //{
            //    sealId = "1585654993174120102"//印章id
            //};
            //var employeeInfo = new OpenAPI.Models.sealAuth.employeeInfo()
            //{
            //    unionId = "137a1c56d9fa4f69a89cff09aa02b576"//被授权员工的unionId
            //};
            //var result22 = client.sealAuth(new sealAuthInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    sealInfo = sealInfo,
            //    employeeInfo = employeeInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result22));
            #endregion

            #region 3.23 取消授权
            var sealInfo = new OpenAPI.Models.cancelSealAuth.sealInfo()
            {
                sealId = "1585654993174120102"//印章id
            };
            var employeeInfo = new OpenAPI.Models.cancelSealAuth.employeeInfo()
            {
                unionId = "137a1c56d9fa4f69a89cff09aa02b576"//被授权员工的unionId
            };
            var result23 = client.cancelSealAuth(new cancelSealAuthInput()
            {
                SignType = "HMAC-SHA256",
                Nonce = System.Guid.NewGuid().ToString("N"),
                Token = "992a09fb134641f1a242fb5af888beb8",
                sealInfo = sealInfo,
                employeeInfo = employeeInfo
            });
            Console.WriteLine(JsonConvert.SerializeObject(result23));
            #endregion

            #region 3.24 查询企业印章列表
            //var sealInfo = new OpenAPI.Models.companySealList.sealInfo()
            //{
            //    loadUnPass = 0//是否同时加载未审核通过的 1 是， 0 否
            //};

            //var result24 = client.companySealList(new companySealListInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    sealInfo = sealInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result24));
            #endregion

            #region 3.25 查询企业印章详情
            //var sealInfo = new OpenAPI.Models.companySealDetail.sealInfo()
            //{
            //    sealId = "1600323891079166571"//印章id
            //};

            //var result25 = client.companySealDetail(new companySealDetailInput()
            //{
            //    SignType = "HMAC-SHA256",
            //    Nonce = System.Guid.NewGuid().ToString("N"),
            //    Token = "992a09fb134641f1a242fb5af888beb8",
            //    sealInfo = sealInfo
            //});
            //Console.WriteLine(JsonConvert.SerializeObject(result25));
            #endregion

            Console.ReadLine();

        }
    }
}
