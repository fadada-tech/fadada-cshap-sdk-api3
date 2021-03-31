using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.SDKModels.Template
{
   public class GetTemplateDetailResponse
    {
        public string templateId { get; set; }
        public string templateName { get; set; }
        public string templateRemark { get; set; }
        public int status { get; set; }
        public List<TemplateFiles> templateFiles { get; set; }
        public List<Roles> roles { get; set; }
        public class TemplateFiles
        {
            public string fileId { get; set; }
            public string fileName { get; set; }
            public string fileUuid { get; set; }
            public int fileType { get; set; }
            public List<RoleWidgets> roleWidgets { get; set; }
        }
        public class RoleWidgets
        {
            public string roleName { get; set; }
            public List<Widgets> widgets { get; set; }
        }
        public class Widgets
        {
            public string widgetName { get; set; }
            public string widgetValue { get; set; }
            public int signStyle { get; set; }
            public int isRequired { get; set; }
        }
        public class Roles
        {
            public string roleId { get; set; }
            public string roleName { get; set; }
            public int rolePermission { get; set; }
            public int roleType { get; set; }
            public int signSort { get; set; }
            public int fillSort { get; set; }
        }

    }
}
