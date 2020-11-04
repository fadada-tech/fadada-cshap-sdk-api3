using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class company
    {
        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string companyName
        {
            set;
            get;
        }
    }
}
