using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class createByTemplateInput:baseInput
    {
        [JsonProperty("templateId", NullValueHandling = NullValueHandling.Ignore)]
        public string templateId
        {
            set;
            get;
        }
        [JsonProperty("templateFiles", NullValueHandling = NullValueHandling.Ignore)]
        public List<templateFiles> templateFiles
        {
            set;
            get;
        }
    }
    public class templateFiles
    {
        [JsonProperty("templateFileId", NullValueHandling = NullValueHandling.Ignore)]
        public string templateFileId
        {
            set;
            get;
        }
        [JsonProperty("formFields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> formFields
        {
            set;
            get;
        }
        [JsonProperty("documentFileName", NullValueHandling = NullValueHandling.Ignore)]
        public string documentFileName
        {
            set;
            get;
        }
    }
}
