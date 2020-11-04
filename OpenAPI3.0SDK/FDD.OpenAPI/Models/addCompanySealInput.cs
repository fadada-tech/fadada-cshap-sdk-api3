using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.addCompanySeal
{
   public class addCompanySealInput:baseInput
    {
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public string image
        {
            set;
            get;
        }
        [JsonProperty("sealInfo", NullValueHandling = NullValueHandling.Ignore)]
        public sealInfo sealInfo
        {
            set;
            get;
        }
    }
    public class sealInfo
    {
        [JsonProperty("imageHash", NullValueHandling = NullValueHandling.Ignore)]
        public string imageHash
        {
            set;
            get;
        }
        [JsonProperty("sealName", NullValueHandling = NullValueHandling.Ignore)]
        public string sealName
        {
            set;
            get;
        }
    }
}
