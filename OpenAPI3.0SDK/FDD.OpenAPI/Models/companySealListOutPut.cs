using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class companySealListOutPut:baseOutput
    {
        public companySealListdata data
        {
            set;
            get;
        }
    }

    public class companySealListdata
    {
        public seals seals
        {
            set;
            get;
        }
    }
    public class seals
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
    }
}
