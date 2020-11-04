using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.createByDraftId
{
   public class createByDraftIdOutPut:baseOutput
    {
        public createByDraftIddata data
        {
            set;
            get;
        }
    }
    public class createByDraftIddata
    {
        public string taskId
        {
            set;
            get;
        }
        public List<signFileIds> signFileIds
        {
            set;
            get;
        }
    }
    public class signFileIds
    {
        public string signFileId
        {
            set;
            get;
        }
    }
}
