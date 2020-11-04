using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class accessTokenOutput:baseOutput
    {
       public accessTokendata data
        {
            set;
            get;
        }
    }
    public class accessTokendata
    {
       public string accessToken
        {
            set;
            get;
        }
       public string expiresIn
        {
            set;
            get;
        }
       public string expiresTime
        {
            set;
            get;
        }
    }
}
