using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class uploadFileInput:baseInput
    {
        [JsonProperty("fileContent", NullValueHandling = NullValueHandling.Ignore)]
        public string fileContent
        {
            set;
            get;
        }
        [JsonProperty("fileType", NullValueHandling = NullValueHandling.Ignore)]
        public string fileType
        {
            set;
            get;
        }
        [JsonProperty("fileContentHash", NullValueHandling = NullValueHandling.Ignore)]
        public string fileContentHash
        {
            set;
            get;
        }
    }
}
