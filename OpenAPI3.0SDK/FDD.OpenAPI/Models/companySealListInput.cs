using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.companySealList
{
   public class companySealListInput:baseInput
    {
        [JsonProperty("sealInfo", NullValueHandling = NullValueHandling.Ignore)]
        public sealInfo sealInfo
        {
            set;
            get;
        }
    }
    public class sealInfo
    {
        [JsonProperty("loadUnPass", NullValueHandling = NullValueHandling.Ignore)]
        public int loadUnPass
        {
            set;
            get;
        }
    }
}
