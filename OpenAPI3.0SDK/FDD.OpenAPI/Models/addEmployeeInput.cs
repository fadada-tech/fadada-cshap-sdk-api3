using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class addEmployeeInput:baseInput
    {
        [JsonProperty("employeeInfo", NullValueHandling = NullValueHandling.Ignore)]
        public employeeInfo employeeInfo
        {
            set;
            get;
        }
    }
}
