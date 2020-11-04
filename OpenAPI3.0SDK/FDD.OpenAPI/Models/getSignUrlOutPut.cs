using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getSignUrlOutPut:baseOutput
    {
        public getSignUrldata data
        {
            set;
            get;
        }
    }
    public class getSignUrldata
    {
        public List<signUrls> signUrls
        {
            set;
            get;
        }
    }
    public class signUrls
    {
        public string signUrl
        {
            set;
            get;
        }
    }
}
