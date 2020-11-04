using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.delCompanySeal
{
   public class delCompanySealInput:baseInput
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
        [JsonProperty("sealId", NullValueHandling = NullValueHandling.Ignore)]
        public string sealId
        {
            set;
            get;
        }
    }
}
