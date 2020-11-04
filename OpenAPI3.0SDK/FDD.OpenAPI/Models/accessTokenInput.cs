using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class accessTokenInput : baseInput
    {
        [JsonProperty("X-FDD-Api-Grant-Type", NullValueHandling = NullValueHandling.Ignore)]
        public string GrantType
        {
            set;
            get;
        }
    }
}
