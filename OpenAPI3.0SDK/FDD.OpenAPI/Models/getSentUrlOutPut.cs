using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getSentUrlOutPut:baseOutput
    {
        public getSentUrldata data
        {
            set;
            get;
        }
    }
    public class getSentUrldata
    {
        public string sentUrl
        {
            set;
            get;
        }
    }
}
