using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getCompanyInfoOutPut:baseOutput
    {
        public getCompanyInfodata data
        {
            set;
            get;
        }
    }

    public class getCompanyInfodata
    {
        public string unionId
        {
            set;
            get;
        }
        public companyInfo companyInfo
        {
            set;
            get;
        }
        public applicantCompanyInfo applicant
        {
            set;
            get;
        }
    }

    public class companyInfo
    {
        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public notice companyName
        {
            set;
            get;
        }
        [JsonProperty("organizationCard", NullValueHandling = NullValueHandling.Ignore)]
        public notice organizationCard
        {
            set;
            get;
        }
        [JsonProperty("authenticateStatus", NullValueHandling = NullValueHandling.Ignore)]
        public notice authenticateStatus
        {
            set;
            get;
        }
        [JsonProperty("organizationType", NullValueHandling = NullValueHandling.Ignore)]
        public notice organizationType
        {
            set;
            get;
        }
        [JsonProperty("hasAgent", NullValueHandling = NullValueHandling.Ignore)]
        public notice hasAgent
        {
            set;
            get;
        }
        [JsonProperty("legalName", NullValueHandling = NullValueHandling.Ignore)]
        public notice legalName
        {
            set;
            get;
        }
    }

    public class applicantCompanyInfo
    {
        [JsonProperty("applicantName", NullValueHandling = NullValueHandling.Ignore)]
        public notice companyName
        {
            set;
            get;
        }
        [JsonProperty("applicantMobile", NullValueHandling = NullValueHandling.Ignore)]
        public notice applicantMobile
        {
            set;
            get;
        }
    }
}
