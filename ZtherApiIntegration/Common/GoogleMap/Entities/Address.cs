using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Common.GoogleMap.Entities
{
    public class Address
    {
        [JsonProperty("long_name")]
        public string Long_Name { get; set; }

        [JsonProperty("short_name")]
        public string Short_Name { get; set; }

        [JsonProperty("types")]
        public IList<string> Types { get; set; }
    }
}