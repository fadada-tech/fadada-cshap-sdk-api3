using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models.createByFile
{
   public class createByFileInput:baseInput
    {
        [JsonProperty("taskSubject", NullValueHandling = NullValueHandling.Ignore)]
        public string taskSubject
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
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<files> files
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

        [JsonProperty("signWay", NullValueHandling = NullValueHandling.Ignore)]
        public string signWay
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
        [JsonProperty("fileSigns", NullValueHandling = NullValueHandling.Ignore)]
        public List<fileSigns> fileSigns
        {
            set;
            get;
        }
    }
    public class fileSigns
    {
        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public string fileId
        {
            set;
            get;
        }
        [JsonProperty("signHeres", NullValueHandling = NullValueHandling.Ignore)]
        public List<signHeres> signHeres
        {
            set;
            get;
        }
    }
    public class signHeres
    {
        [JsonProperty("pageNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string pageNumber
        {
            set;
            get;
        }
        [JsonProperty("xCoordinate", NullValueHandling = NullValueHandling.Ignore)]
        public string xCoordinate
        {
            set;
            get;
        }
        [JsonProperty("yCoordinate", NullValueHandling = NullValueHandling.Ignore)]
        public string yCoordinate
        {
            set;
            get;
        }
    }
    public class files
    {
        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public string fileId
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
        [JsonProperty("authorizedUnionId", NullValueHandling = NullValueHandling.Ignore)]
        public string authorizedUnionId
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
        [JsonProperty("fileSigns", NullValueHandling = NullValueHandling.Ignore)]
        public List<fileSigns> fileSigns
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
