using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getCompanyUnionIdUrlOutPut:baseOutput
    {
        public getCompanyUnionIdUrldata data
        {
            set;
            get;
        }
    }
    public class getCompanyUnionIdUrldata
    {
        public string nextUrl
        {
            set;
            get;
        }
        public string clientId
        {
            set;
            get;
        }
    }
}
