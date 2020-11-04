using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDD.OpenAPI
{
    /// <summary>
    /// @author zhangyongliang
    /// @version 3.0.0
    /// @date 2020/09/11
    /// </summary>
    public static class Apis
    {
        internal const string AccessToken = "/oauth2/accessToken";
        internal const string GetAuthorizeUrl = "/oauth2/getAuthorizeUrl";
        internal const string GetPersonUnionIdUrl = "/accounts/getPersonUnionIdUrl";
        internal const string GetCompanyUnionIdUrl = "/accounts/getCompanyUnionIdUrl";
        internal const string GetPersonInfo = "/accounts/getPersonInfo";
        internal const string GetCompanyInfo = "/accounts/getCompanyInfo";
        internal const string UploadFile = "/documents/uploadFile";
        internal const string GetTemplateDetailById = "/documents/getTemplateDetailById";
        internal const string CreateByTemplate = "/documents/createByTemplate";
        internal const string GetByDraftId = "/documents/getByDraftId";
        internal const string GetBySignFileId = "/documents/getBySignFileId";
        internal const string CreateByFile = "/signtasks/createByFile";
        internal const string GetSentUrl = "/signtasks/getSentUrl";
        internal const string CreateByDraftId = "/signtasks/createByDraftId";
        internal const string GetSignUrl = "/signtasks/getSignUrl";
        internal const string GetTaskDetailByTaskId = "/signtasks/getTaskDetailByTaskId";
        internal const string Cancel = "/signtasks/cancel";
        internal const string AddEmployee = "/org/employee/addEmployee";
        internal const string DelEmployee = "/org/employee/delEmployee";
        internal const string AddCompanySeal = "/seal/addCompanySeal";
        internal const string DelCompanySeal = "/seal/delCompanySeal";
        internal const string SealAuth = "/seal/sealAuth";
        internal const string CancelSealAuth = "/seal/cancelSealAuth";
        internal const string CompanySealList = "/seal/companySealList";
        internal const string CompanySealDetail = "/seal/companySealDetail";
    }
}
