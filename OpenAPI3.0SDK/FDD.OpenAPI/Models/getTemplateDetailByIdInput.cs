using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getTemplateDetailByIdInput:baseInput
    {
        [JsonProperty("templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string templateId
        {
            set;
            get;
        }
    }
}
