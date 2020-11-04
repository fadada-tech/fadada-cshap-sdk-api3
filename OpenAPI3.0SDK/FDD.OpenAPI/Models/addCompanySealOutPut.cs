using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class addCompanySealOutPut:baseOutput
    {
        public addCompanySealdata data
        {
            set;
            get;
        }
    }
    public class addCompanySealdata
    {
        public string sealId
        {
            set;
            get;
        }
    }
}
