using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class notice
    {
        [JsonProperty("notifyWay", NullValueHandling = NullValueHandling.Ignore)]
        public string notifyWay
        {
            set;
            get;
        }
        [JsonProperty("notifyAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string notifyAddress
        {
            set;
            get;
        }
    }
}
