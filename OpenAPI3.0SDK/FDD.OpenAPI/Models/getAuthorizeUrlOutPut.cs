using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getAuthorizeUrlOutPut : baseOutput
    {
        public getAuthorizeUrldata data
        {
            set;
            get;
        }
    }
    public class getAuthorizeUrldata
    {
        public string authorizeUrl
        {
            set;
            get;
        }
    }
}
