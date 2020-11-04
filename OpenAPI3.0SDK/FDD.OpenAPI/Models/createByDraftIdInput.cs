using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class createByDraftIdInput:baseInput
    {
        [JsonProperty("taskSubject", NullValueHandling = NullValueHandling.Ignore)]
        public string taskSubject
        {
            set;
            get;
        }
        [JsonProperty("draftId", NullValueHandling = NullValueHandling.Ignore)]
        public string draftId
        {
            set;
            get;
        }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string status
        {
            set;
            get;
        }
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public int sort
        {
            set;
            get;
        }
        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public sender sender
        {
            set;
            get;
        }
        [JsonProperty("signers", NullValueHandling = NullValueHandling.Ignore)]
        public List<signers> signers
        {
            set;
            get;
        }
        [JsonProperty("autoArchive", NullValueHandling = NullValueHandling.Ignore)]
        public int autoArchive
        {
            set;
            get;
        }
        [JsonProperty("taskConfig", NullValueHandling = NullValueHandling.Ignore)]
        public object taskConfig
        {
            set;
            get;
        }
    }
    public class sender
    {
        [JsonProperty("signOrder", NullValueHandling = NullValueHandling.Ignore)]
        public string signOrder
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
        [JsonProperty("templateRoleName", NullValueHandling = NullValueHandling.Ignore)]
        public string templateRoleName
        {
            set;
            get;
        }
    }

    public class signers
    {
        [JsonProperty("unionId", NullValueHandling = NullValueHandling.Ignore)]
        public string unionId
        {
            set;
            get;
        }
        [JsonProperty("externalSigner", NullValueHandling = NullValueHandling.Ignore)]
        public externalSigner externalSigner
        {
            set;
            get;
        }
        [JsonProperty("authorizedUnionId", NullValueHandling = NullValueHandling.Ignore)]
        public string authorizedUnionId
        {
            set;
            get;
        }
        [JsonProperty("signOrder", NullValueHandling = NullValueHandling.Ignore)]
        public int signOrder
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
        [JsonProperty("templateRoleName", NullValueHandling = NullValueHandling.Ignore)]
        public string templateRoleName
        {
            set;
            get;
        }
    }
    public class externalSigner
    {
        [JsonProperty("mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string mobile
        {
            set;
            get;
        }
        [JsonProperty("personName", NullValueHandling = NullValueHandling.Ignore)]
        public string personName
        {
            set;
            get;
        }
        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string companyName
        {
            set;
            get;
        }
    }
}
