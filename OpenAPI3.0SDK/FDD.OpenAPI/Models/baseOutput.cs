using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
    public abstract class baseOutput
    {
        public string code
        {
            set;
            get;
        }
        public string msg
        {
            set;
            get;
        }
    }
}
