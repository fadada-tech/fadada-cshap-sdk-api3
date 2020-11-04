using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class person
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public notice name
        {
            set;
            get;
        }
        [JsonProperty("identType", NullValueHandling = NullValueHandling.Ignore)]
        public notice identType
        {
            set;
            get;
        }
        [JsonProperty("identNo", NullValueHandling = NullValueHandling.Ignore)]
        public notice identNo
        {
            set;
            get;
        }
        [JsonProperty("mobile", NullValueHandling = NullValueHandling.Ignore)]
        public notice mobile
        {
            set;
            get;
        }
    }
}
