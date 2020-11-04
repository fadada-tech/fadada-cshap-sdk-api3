using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
    public class getPersonInfoOutPut : baseOutput
    {
        public getPersonInfodata data
        {
            set;
            get;
        }
    }
    public class getPersonInfodata
    {
        public string unionId
        {
            set;
            get;
        }
        public string status
        {
            set;
            get;
        }
        public getPersonInfoperson person
        {
            set;
            get;
        }
    }
    public class getPersonInfoperson
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public notice name
        {
            set;
            get;
        }
        [JsonProperty("idCard", NullValueHandling = NullValueHandling.Ignore)]
        public notice idCard
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
