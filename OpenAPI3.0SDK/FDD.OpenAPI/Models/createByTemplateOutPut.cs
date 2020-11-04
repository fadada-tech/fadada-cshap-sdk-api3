using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class createByTemplateOutPut:baseOutput
    {
        public createByTemplatedata data
        {
            set;
            get;
        }
    }
    public class createByTemplatedata
    {
        public string draftId
        {
            set;
            get;
        }
        public List<draftFileIds> draftFileIds
        {
            set;
            get;
        }
    }
    public class draftFileIds
    {
        public string draftFileId
        {
            set;
            get;
        }
    }
}
