﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getSignUrlInput:baseInput
    {
        [JsonProperty("taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string taskId
        {
            set;
            get;
        }
        [JsonProperty("unionId", NullValueHandling = NullValueHandling.Ignore)]
        public string unionId
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
    }
}