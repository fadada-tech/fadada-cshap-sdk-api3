using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getPersonUnionIdUrlOutPut : baseOutput
    {
        public getPersonUnionIdUrldata data
        {
            set;
            get;
        }
    }
    public class getPersonUnionIdUrldata
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
