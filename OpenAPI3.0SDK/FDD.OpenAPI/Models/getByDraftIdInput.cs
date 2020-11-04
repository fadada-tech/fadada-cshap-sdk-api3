using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDD.OpenAPI.Models
{
   public class getByDraftIdInput:baseInput
    {
        [JsonProperty("draftId", NullValueHandling = NullValueHandling.Ignore)]
        public string draftId
        {
            set;
            get;
        }
        [JsonProperty("draftFileId", NullValueHandling = NullValueHandling.Ignore)]
        public string draftFileId
        {
            set;
            get;
        }
    }
}
