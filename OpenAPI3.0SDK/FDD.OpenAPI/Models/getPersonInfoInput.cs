using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getPersonInfoInput:baseInput
    {
        [JsonProperty("unionId", NullValueHandling = NullValueHandling.Ignore)]
        public string unionId
        {
            set;
            get;
        }
    }
}
