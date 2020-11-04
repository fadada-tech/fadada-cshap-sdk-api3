using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class cancelInput:baseInput
    {
        [JsonProperty("taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string taskId
        {
            set;
            get;
        }

        [JsonProperty("remark", NullValueHandling = NullValueHandling.Ignore)]
        public string remark
        {
            set;
            get;
        }
    }
}
