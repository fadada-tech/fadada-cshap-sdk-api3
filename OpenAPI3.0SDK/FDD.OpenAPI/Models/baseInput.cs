using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
    public class baseInput: IbaseInput
    {
        [JsonProperty("X-FDD-Api-App-Id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId
        {
            set;
            get;
        }
        [JsonProperty("X-FDD-Api-Sign-Type", NullValueHandling = NullValueHandling.Ignore)]
        public string SignType
        {
            set;
            get;
        }
        [JsonProperty("X-FDD-Api-Sign", NullValueHandling = NullValueHandling.Ignore)]
        public string Sign
        {
            set;
            get;
        }
        [JsonProperty("X-FDD-Api-Timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp
        {
            set;
            get;
        }
        [JsonProperty("X-FDD-Api-Nonce", NullValueHandling = NullValueHandling.Ignore)]
        public string Nonce
        {
            set;
            get;
        }
        [JsonProperty("X-FDD-Api-Token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token
        {
            set;
            get;
        }
        [JsonProperty("bizContent", NullValueHandling = NullValueHandling.Ignore)]
        public string bizContent
        {
            set;
            get;
        }
    }
}
