using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getCompanyUnionIdUrlInput:baseInput
    {
        [JsonProperty("clientId", NullValueHandling = NullValueHandling.Ignore)]
        public string clientId
        {
            set;
            get;
        }
        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public company company
        {
            set;
            get;
        }
        [JsonProperty("applicant", NullValueHandling = NullValueHandling.Ignore)]
        public applicant applicant
        {
            set;
            get;
        }
        [JsonProperty("notice", NullValueHandling = NullValueHandling.Ignore)]
        public notice notice
        {
            set;
            get;
        }

        [JsonProperty("authScope", NullValueHandling = NullValueHandling.Ignore)]
        public string authScope
        {
            set;
            get;
        }

        [JsonProperty("redirectUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string redirectUrl
        {
            set;
            get;
        }

        [JsonProperty("allowModify", NullValueHandling = NullValueHandling.Ignore)]
        public string allowModify
        {
            set;
            get;
        }
    }
}
