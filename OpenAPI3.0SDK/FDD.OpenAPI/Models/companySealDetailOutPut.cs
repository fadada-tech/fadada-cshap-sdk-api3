using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class companySealDetailOutPut:baseOutput
    {
        public companySealDetaildata data
        {
            set;
            get;
        }
    }
    public class companySealDetaildata
    {
        public string sealId
        {
            set;
            get;
        }
        public string sealName
        {
            set;
            get;
        }
        public string status
        {
            set;
            get;
        }
        public string sysFlag
        {
            set;
            get;
        }
        public string base64
        {
            set;
            get;
        }
        public List<sealHolders> sealHolders
        {
            set;
            get;
        }
    }
    public class sealHolders
    {
        public string unionId
        {
            set;
            get;
        }
    }
}
