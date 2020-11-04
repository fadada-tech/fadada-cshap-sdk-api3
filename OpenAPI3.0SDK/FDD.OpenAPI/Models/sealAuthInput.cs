using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.sealAuth
{
   public class sealAuthInput:baseInput
    {
        [JsonProperty("sealInfo", NullValueHandling = NullValueHandling.Ignore)]
        public sealInfo sealInfo
        {
            set;
            get;
        }
        [JsonProperty("employeeInfo", NullValueHandling = NullValueHandling.Ignore)]
        public employeeInfo employeeInfo
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
    public class employeeInfo
    {
        [JsonProperty("unionId", NullValueHandling = NullValueHandling.Ignore)]
        public string unionId
        {
            set;
            get;
        }
    }
}
