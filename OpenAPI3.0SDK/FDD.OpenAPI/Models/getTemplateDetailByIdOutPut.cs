using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getTemplateDetailByIdOutPut:baseOutput
    {
        public getTemplateDetailByIddata data
        {
            set;
            get;
        }
    }
    public class getTemplateDetailByIddata
    {
        public string templateId
        {
            set;
            get;
        }
        public string templateFiles
        {
            set;
            get;
        }
    }
}
