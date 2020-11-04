using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class uploadFileOutPut:baseOutput
    {
        public uploadFiledata data
        {
            set;
            get;
        }
    }
    public class uploadFiledata
    {
        public string fileId
        {
            set;
            get;
        }
    }
}
